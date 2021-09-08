using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Services
{
    public class EmailService : IEmailService
    {
		private const string templatePath = @"EmailTemplate/{0}.html";
		private readonly SMTPConfigModel _smtpConfig;

		public async Task SendTestEmail(UserEmailOptionModel userEmailOption)
		{
			userEmailOption.Subject = UpdatePlaceHolders("Hello {{UserName}}, this is test email subject from book store web app", userEmailOption.PlaceHolders);
			userEmailOption.Body = UpdatePlaceHolders(GetEmailBody("TestEmail"), userEmailOption.PlaceHolders);

			await SendEmail(userEmailOption);

		}
		
		public async Task SendEmailForEmailConfirmation(UserEmailOptionModel userEmailOption)
		{
			userEmailOption.Subject = UpdatePlaceHolders("Hello {{UserName}}, Confirm your email id", userEmailOption.PlaceHolders);
			userEmailOption.Body = UpdatePlaceHolders(GetEmailBody("EmailConfirm"), userEmailOption.PlaceHolders);

			await SendEmail(userEmailOption);

		}

		public EmailService(IOptions<SMTPConfigModel> smtpConfig)
		{
			_smtpConfig = smtpConfig.Value;
		}
        private async Task SendEmail(UserEmailOptionModel userEmailOption)
		{
			MailMessage mail = new()
			{
				Subject = userEmailOption.Subject,
				Body = userEmailOption.Body,
				From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
				IsBodyHtml = _smtpConfig.IsBodyHTML
			};

			foreach (var toEmail in userEmailOption.ToEmails)
			{
				mail.To.Add(toEmail);
			}

			NetworkCredential networkCredential = new(_smtpConfig.UserName, _smtpConfig.Password);
			SmtpClient smtpClient = new()
			{
				Host = _smtpConfig.Host,
				Port = _smtpConfig.Port,
				EnableSsl = _smtpConfig.EnableSSL,
				UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
				Credentials = networkCredential
			};

			mail.BodyEncoding = Encoding.Default;

			await smtpClient.SendMailAsync(mail);
		}

		private string GetEmailBody(string templateName)
		{
			var body = File.ReadAllText(string.Format(templatePath, templateName));
			return body;
		}

		private string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
		{
			if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
			{
				foreach (var placeholder in keyValuePairs)
				{
					if (text.Contains(placeholder.Key))
					{
						text = text.Replace(placeholder.Key, placeholder.Value);
					}
				}
			}
			return text;
		}

    }
}
