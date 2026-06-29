using Tamrin.Models;
using Tamrin.Share;

namespace Tamrin.Services;

public static  class Validator
{
   public static void PersonValidator(this Person person)
   {
      if (string.IsNullOrEmpty(person.UserName))
         throw new UnauthorizedAccessException("نام کاربری نمیتواند خالی باشد ");
      else if (string.IsNullOrEmpty(person.Password))
         throw new UnauthorizedAccessException("رمز عبور نمیتواند خالی باشد");
   }
}