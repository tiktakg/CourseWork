using qwewr.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GoodAuthorization.Models
{
	internal class randomTable
	{
		public static DBContext случай_база;
			static randomTable()
		{
			try
			{
				случай_база = new DBContext();
			}
			catch (Exception) { MessageBox.Show("Error of connection to database", MessageBoxButton.OK.ToString()); }
		}
	}
}
