﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Interfaces
{
    public interface IUserService
    {
		string GetUserId();
		bool IsAuthenticated();
	}
}
