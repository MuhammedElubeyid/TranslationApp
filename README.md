# AI Translation App

AI Translation App is a simple Windows Forms application built with C#.  
The application allows users to enter text, choose a target language, and translate the text using the Groq AI API.

This project was created as a university project to demonstrate how to connect a desktop application with an external AI API.

---

## Features

- Translate text using Groq AI
- Simple Windows Forms interface
- Supports multiple languages:
  - Arabic
  - English
  - Turkish
  - French
  - German
  - Spanish
- Clean and easy-to-use design
- Displays translation result inside the application

---

## Technologies Used

- C#
- Windows Forms
- .NET
- Groq AI API
- HTTP Client
- JSON Serialization

---

## How the Application Works

The user writes text inside the input box and selects the target language.

Then the application sends the text to Groq API.  
Groq processes the request and returns the translated text.

Basic workflow:

```text
User Input
   ↓
Windows Forms App
   ↓
Groq API
   ↓
Translation Result
How to Run the Project
Clone or download the project.
Open the project in Visual Studio.
Create a Groq API key from Groq Console.
Open Form1.cs.
Find this line:
string apiKey = "PUT_YOUR_GROQ_API_KEY_HERE";
Replace it with your own Groq API key:
string apiKey = "your_api_key_here";
Run the application.
