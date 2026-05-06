using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace TranslationApp
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

private void Form1_Load(object sender, EventArgs e)
{
    // Form settings
    this.Text = "AI Translation App";
    this.Size = new Size(850, 550);
    this.StartPosition = FormStartPosition.CenterScreen;
    this.BackColor = Color.FromArgb(245, 247, 250);
    this.Font = new Font("Segoe UI", 10);

    // Title label
    Label lblTitle = new Label();
    lblTitle.Text = "AI Translation App";
    lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
    lblTitle.ForeColor = Color.FromArgb(40, 40, 40);
    lblTitle.AutoSize = true;
    lblTitle.Location = new Point(280, 25);
    this.Controls.Add(lblTitle);

    // Input label
    Label lblInput = new Label();
    lblInput.Text = "Enter text:";
    lblInput.Font = new Font("Segoe UI", 11, FontStyle.Bold);
    lblInput.Location = new Point(60, 90);
    lblInput.AutoSize = true;
    this.Controls.Add(lblInput);

    // Output label
    Label lblOutput = new Label();
    lblOutput.Text = "Translation result:";
    lblOutput.Font = new Font("Segoe UI", 11, FontStyle.Bold);
    lblOutput.Location = new Point(60, 290);
    lblOutput.AutoSize = true;
    this.Controls.Add(lblOutput);

    // Language label
    Label lblLanguage = new Label();
    lblLanguage.Text = "Target language:";
    lblLanguage.Font = new Font("Segoe UI", 11, FontStyle.Bold);
    lblLanguage.Location = new Point(570, 90);
    lblLanguage.AutoSize = true;
    this.Controls.Add(lblLanguage);

    // txtInput style
    txtInput.Location = new Point(60, 120);
    txtInput.Size = new Size(430, 140);
    txtInput.Multiline = true;
    txtInput.ScrollBars = ScrollBars.Vertical;
    txtInput.Font = new Font("Segoe UI", 11);

    // txtOutput style
    txtOutput.Location = new Point(60, 320);
    txtOutput.Size = new Size(430, 140);
    txtOutput.Multiline = true;
    txtOutput.ScrollBars = ScrollBars.Vertical;
    txtOutput.Font = new Font("Segoe UI", 11);
    txtOutput.ReadOnly = true;
    txtOutput.BackColor = Color.White;

    // ComboBox style
    cmbLanguage.Location = new Point(570, 120);
    cmbLanguage.Size = new Size(200, 35);
    cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
    cmbLanguage.Font = new Font("Segoe UI", 11);

    cmbLanguage.Items.Clear();
    cmbLanguage.Items.Add("Arabic");
    cmbLanguage.Items.Add("English");
    cmbLanguage.Items.Add("Turkish");
    cmbLanguage.Items.Add("French");
    cmbLanguage.Items.Add("German");
    cmbLanguage.Items.Add("Spanish");

    cmbLanguage.SelectedIndex = 0;

    // Button style
    btnTranslate.Location = new Point(570, 190);
    btnTranslate.Size = new Size(200, 45);
    btnTranslate.Text = "Translate";
    btnTranslate.Font = new Font("Segoe UI", 12, FontStyle.Bold);
    btnTranslate.BackColor = Color.FromArgb(0, 120, 215);
    btnTranslate.ForeColor = Color.White;
    btnTranslate.FlatStyle = FlatStyle.Flat;
    btnTranslate.FlatAppearance.BorderSize = 0;
    btnTranslate.Cursor = Cursors.Hand;
}

        private async Task<string> TranslateWithGroq(string text, string targetLanguage)
        {
            string apiKey = "PUT_YOUR_GROQ_API_KEY_HERE";

            // Check if API Key is missing or not changed
            if (string.IsNullOrWhiteSpace(apiKey) ||
                apiKey == "PUT_YOUR_GROQ_API_KEY_HERE" ||
                !apiKey.StartsWith("gsk_"))
            {
                return "Please put your Groq API Key first.";
            }

            string url = "https://api.groq.com/openai/v1/chat/completions";

            var requestBody = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
            new
            {
                role = "system",
                content = "You are a professional translation assistant. Translate accurately and return only the translated text."
            },
            new
            {
                role = "user",
                content = $"Translate this text to {targetLanguage}: {text}"
            }
        },
                temperature = 0.2
            };

            string json = JsonSerializer.Serialize(requestBody);

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", $"Bearer {apiKey}");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            string responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                string lowerError = responseText.ToLower();

                if (lowerError.Contains("invalid_api_key") || lowerError.Contains("invalid api key"))
                {
                    return "Please put your correct Groq API Key first.";
                }

                return "Something went wrong. Please try again.";
            }

            using JsonDocument doc = JsonDocument.Parse(responseText);

            string translatedText = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return translatedText;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Please enter text first.");
                return;
            }

            if (cmbLanguage.SelectedItem == null)
            {
                MessageBox.Show("Please select a language.");
                return;
            }

            string targetLanguage = cmbLanguage.SelectedItem.ToString();

            btnTranslate.Enabled = false;
            btnTranslate.Text = "Translating...";

            try
            {
                string result = await TranslateWithGroq(inputText, targetLanguage);
                txtOutput.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            btnTranslate.Enabled = true;
            btnTranslate.Text = "Translate";
        }
    }
}