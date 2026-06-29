using Tamrin.Models;
using Tamrin.Share;

namespace Tamrin.Services;

public static  class Validator
{
   public static OperationResult PersonValidator(this Person person)
   {
      if (person.UserName.Length < 1)
         return OperationResult.Feilure("نام کاربری کوتاه است");
      else if (person.Password.Length < 1)
         return OperationResult.Feilure("رمز عبور کوتاه است");
      return  OperationResult.Success();
   }
}