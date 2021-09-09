using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Interfaces
{
    public interface IEmailService
    {
		Task SendTestEmail(UserEmailOptionModel userEmailOption);
		Task SendEmailForEmailConfirmation(UserEmailOptionModel userEmailOption);
		Task SendEmailForForgotPassword(UserEmailOptionModel userEmailOption);
	}
}
