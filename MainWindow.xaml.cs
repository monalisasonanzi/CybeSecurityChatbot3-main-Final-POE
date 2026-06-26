using CyberSecurityChatbot3.Models;
using CyberSecurityChatbot3.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CyberSecurityChatbot3
{
    public partial class MainWindow : Window
    {
        private ChatbotService chatbot;
        private SentimentService sentiment;
        private ActivityLogger logger;

        private Dictionary<string, string> memory;

        private List<CyberTask> tasks;

        private List<QuizQuestion> questions;
        private int currentQuestion = 0;
        private int score = 0;

        public MainWindow()
        {
            InitializeComponent();

            chatbot = new ChatbotService();
            sentiment = new SentimentService();
            logger = new ActivityLogger();

            memory = new Dictionary<string, string>();
            tasks = new List<CyberTask>();

            questions = new List<QuizQuestion>()
            {
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    CorrectAnswer = "B"
                },

                new QuizQuestion
                {
                    Question = "What does 2FA stand for?",
                    CorrectAnswer = "A"
                }
            };

            LoadQuestion();

            txtChat.Text +=
                "Bot: Hello! Welcome to the Cybersecurity Awareness Chatbot. What is your name?\n\n";

            logger.Log("Application Started");
            RefreshLogs();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            string userMessage = txtMessage.Text.Trim();
            string message = userMessage.ToLower();

            txtChat.Text += "You: " + userMessage + "\n";

            logger.Log("User message: " + userMessage);

            string response = "";

            if (message.Contains("my name is"))
            {
                string name = userMessage
                    .Replace("my name is", "")
                    .Trim();

                memory["name"] = name;

                response = "Nice to meet you, " + name +
                           "! I will remember your name.";
            }
            // Remember favourite browser
            else if (message.Contains("my favourite browser is"))
            {
                string browser = userMessage
                    .Replace("my favourite browser is", "")
                    .Trim();

                memory["browser"] = browser;

                response = "Great! I'll remember that your favourite browser is " + browser + ".";
            }

            // Remember favourite operating system
            else if (message.Contains("my favourite operating system is"))
            {
                string os = userMessage
                    .Replace("my favourite operating system is", "")
                    .Trim();

                memory["os"] = os;

                response = "Thanks! I'll remember that you like " + os + ".";
            }

            // Remember favourite programming language
            else if (message.Contains("my favourite programming language is"))
            {
                string language = userMessage
                    .Replace("my favourite programming language is", "")
                    .Trim();

                memory["language"] = language;

                response = "Nice! I'll remember that your favourite programming language is " + language + ".";
            }

            // Remember favourite cybersecurity topic
            else if (message.Contains("my favourite cybersecurity topic is"))
            {
                string topic = userMessage
                    .Replace("my favourite cybersecurity topic is", "")
                    .Trim();

                memory["topic"] = topic;

                response = "Awesome! I'll remember that your favourite cybersecurity topic is " + topic + ".";
            }

            // Recall favourite browser
            else if (message.Contains("what is my favourite browser"))
            {
                response = memory.ContainsKey("browser")
                    ? "Your favourite browser is " + memory["browser"] + "."
                    : "You haven't told me your favourite browser yet.";
            }

            // Recall favourite operating system
            else if (message.Contains("what is my favourite operating system"))
            {
                response = memory.ContainsKey("os")
                    ? "Your favourite operating system is " + memory["os"] + "."
                    : "You haven't told me your favourite operating system yet.";
            }

            // Recall favourite programming language
            else if (message.Contains("what is my favourite programming language"))
            {
                response = memory.ContainsKey("language")
                    ? "Your favourite programming language is " + memory["language"] + "."
                    : "You haven't told me your favourite programming language yet.";
            }

            // Recall favourite cybersecurity topic
            else if (message.Contains("what is my favourite cybersecurity topic"))
            {
                response = memory.ContainsKey("topic")
                    ? "Your favourite cybersecurity topic is " + memory["topic"] + "."
                    : "You haven't told me your favourite cybersecurity topic yet.";
            }
            else if (message.Contains("advice"))
            {
                string name =
                    memory.ContainsKey("name")
                    ? memory["name"]
                    : "friend";

                response =
                    name +
                    ", my cybersecurity advice is: use strong passwords, avoid suspicious links, and enable 2FA.";
            }
            else
            {
                response = chatbot.GetResponse(message);

                if (response.Contains("I am still learning"))
                {
                    string mood =
                        sentiment.DetectSentiment(message);

                    if (mood == "happy")
                        response = "I am glad you are feeling happy today!";

                    else if (mood == "sad")
                        response = "I am sorry you are feeling sad.";

                    else if (mood == "stressed")
                        response = "You sound stressed. Take a break and stay safe online.";
                }
            }

            txtChat.Text += "Bot: " + response + "\n\n";

            logger.Log("Bot response: " + response);

            RefreshLogs();

            txtMessage.Clear();
            txtChat.ScrollToEnd();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTask.Text))
                return;

            CyberTask task = new CyberTask
            {
                TaskName = txtTask.Text,
                IsCompleted = false
            };

            tasks.Add(task);

            lstTasks.Items.Add("🔒 " + task.TaskName);

            logger.Log("Task Added: " + txtTask.Text);

            RefreshLogs();

            txtTask.Clear();
        }

        private void SubmitQuiz_Click(object sender, RoutedEventArgs e)
        {
            string answer = "";

            if (rbA.IsChecked == true)
                answer = "A";

            if (rbB.IsChecked == true)
                answer = "B";

            if (rbC.IsChecked == true)
                answer = "C";

            if (rbD.IsChecked == true)
                answer = "D";

            if (answer == questions[currentQuestion].CorrectAnswer)
            {
                score++;

                logger.Log("Correct answer selected.");
            }
            else
            {
                logger.Log("Incorrect answer selected.");
            }

            currentQuestion++;

            if (currentQuestion >= questions.Count)
            {
                lblScore.Text =
                    "Quiz Complete! Score: " +
                    score +
                    "/" +
                    questions.Count;

                logger.Log("Quiz completed. Score: " + score + "/" + questions.Count);
            }
            else
            {
                LoadQuestion();
            }

            RefreshLogs();
        }

        private void LoadQuestion()
        {
            if (currentQuestion == 0)
            {
                lblQuestion.Text = "What is phishing?";

                rbA.Content = "A firewall";
                rbB.Content = "Attempting to steal information";
                rbC.Content = "An antivirus";
                rbD.Content = "A password";
            }
            else if (currentQuestion == 1)
            {
                lblQuestion.Text = "What does 2FA stand for?";

                rbA.Content = "Two-Factor Authentication";
                rbB.Content = "Two File Access";
                rbC.Content = "Two Firewall Access";
                rbD.Content = "Two Function Approval";
            }
        }

        private void RefreshLogs()
        {
            lstLogs.ItemsSource = null;
            lstLogs.ItemsSource = logger.GetLogs();
        }
    }
}