using System;

namespace CyberSecurityChatbot3.Services
{
    public class ChatbotService
    {
        public string GetResponse(string message)
        {
            message = message.ToLower();
            if (message.Contains("help"))
            {
                return "I can help you with:\n\n" +
                       "• Password Security\n" +
                       "• Phishing\n" +
                       "• Malware\n" +
                       "• Viruses\n" +
                       "• Firewalls\n" +
                       "• VPN\n" +
                       "• Ransomware\n" +
                       "• Social Engineering\n" +
                       "• Antivirus\n" +
                       "• Two-Factor Authentication\n\n" +
                       "Try asking:\n" +
                       "\"What is phishing?\"\n" +
                       "\"How do I create a strong password?\"\n" +
                       "\"What is ransomware?\"";
            }

            // Greetings
            if (message.Contains("hello") ||
    message.Contains("hi") ||
    message.Contains("hey"))
            {
                return "Hello! 👋 Welcome to the Cybersecurity Awareness Assistant.\n\nHow can I help you stay safe online today?";
            }

            // Passwords
            if (message.Contains("password"))
            {
                return "Use strong passwords with at least 12 characters. Include uppercase letters, lowercase letters, numbers, and symbols. Never reuse passwords.";
            }

            // Phishing
            if (message.Contains("phishing"))
            {
                return "Phishing is a cyberattack where criminals pretend to be trusted organisations to steal personal information. Never click suspicious links.";
            }

            // Malware
            if (message.Contains("malware"))
            {
                return "Malware is malicious software that can damage your computer or steal your personal information.";
            }

            // Virus
            if (message.Contains("virus"))
            {
                return "Computer viruses spread between files and devices. Keep your antivirus software updated.";
            }

            // Firewall
            if (message.Contains("firewall"))
            {
                return "A firewall monitors incoming and outgoing network traffic and helps block unauthorized access.";
            }

            // VPN
            if (message.Contains("vpn"))
            {
                return "A VPN encrypts your internet connection, making it more secure especially on public Wi-Fi.";
            }

            // Encryption
            if (message.Contains("encryption"))
            {
                return "Encryption converts information into a secure format so that only authorised users can read it.";
            }

            // Data Breach
            if (message.Contains("data breach"))
            {
                return "A data breach occurs when sensitive information is accessed or stolen without permission.";
            }

            // Identity Theft
            if (message.Contains("identity theft"))
            {
                return "Identity theft happens when criminals steal your personal information to commit fraud.";
            }

            // Safe Browsing
            if (message.Contains("safe browsing"))
            {
                return "Always check website URLs, avoid suspicious downloads, and keep your browser updated.";
            }

            // Wi-Fi
            if (message.Contains("wifi") || message.Contains("wi-fi"))
            {
                return "Avoid entering sensitive information while connected to unsecured public Wi-Fi unless you are using a VPN.";
            }

            // Password Manager
            if (message.Contains("password manager"))
            {
                return "A password manager securely stores your passwords and helps generate strong, unique passwords.";
            }

            // Backup
            if (message.Contains("backup"))
            {
                return "Regular backups help protect your files against ransomware, accidental deletion, and hardware failure.";
            }

            // Ransomware
            if (message.Contains("ransomware"))
            {
                return "Ransomware locks your files until a ransom is paid. Regular backups are the best defence.";
            }

            // Social Engineering
            if (message.Contains("social engineering"))
            {
                return "Social engineering tricks people into revealing confidential information through manipulation.";
            }

            // Antivirus
            if (message.Contains("antivirus"))
            {
                return "Antivirus software detects and removes malicious software before it causes damage.";
            }

            // Two-factor Authentication
            if (message.Contains("2fa") ||
                message.Contains("two factor"))
            {
                return "Two-Factor Authentication adds another layer of security by requiring a second verification method.";
            }

            return "I'm still learning about that topic.\n\nTry asking me about:\n\n" +
       "• Passwords\n" +
       "• Phishing\n" +
       "• Malware\n" +
       "• Viruses\n" +
       "• Firewalls\n" +
       "• VPN\n" +
       "• Encryption\n" +
       "• Backups\n" +
       "• Password Managers\n" +
       "• Two-Factor Authentication";
        }
    }
}