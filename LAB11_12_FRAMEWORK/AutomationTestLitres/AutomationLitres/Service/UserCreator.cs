using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationLitres.Model;

namespace AutomationLitres.Service
{
  public static class UserCreator
  {
    public static string TESTDATA_USER_EMAIL = "oksuroyy@gmail.com";
    public static string TESTDATA_USER_PASSWORD = "Mutabor2003";

    public static User WithCredentials()
    {
        return new User(TESTDATA_USER_EMAIL, TESTDATA_USER_PASSWORD);
    }
  }
}
