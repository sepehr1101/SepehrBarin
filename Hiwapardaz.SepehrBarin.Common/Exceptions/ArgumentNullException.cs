using Hiwapardaz.SepehrBarin.Common.Literals;

namespace Hiwapardaz.SepehrBarin.Common.Exceptions
{
    public class ArgumentIsNullException:ArgumentException
    {
        public ArgumentIsNullException(string argumentName)
            :base($"{ExceptionLiterals.ArgumentIsNull_1} {argumentName}") 
        {            
        }
    }
}
