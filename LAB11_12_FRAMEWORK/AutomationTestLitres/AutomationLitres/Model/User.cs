using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationLitres;

namespace AutomationLitres.Model
{
  public class User
  {
      private string email;
      private string password;

      public User(string email, string password)
      {
        this.email = email;
        this.password = password;
      }

      public string GetEmail()
      {
        return email;
      }

      public void SetEmail(string email)
      {
        this.email = email;
      }

      public string GetPassword()
      {
        return password;
      }

      public void SetPassword(string password)
      {
        this.password = password;
      }
  }
}
