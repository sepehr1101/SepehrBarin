using Hiwapardaz.SepehrBarin.Persistence.Constants.Literals;

namespace Hiwapardaz.SepehrBarin.Persistence.Exceptions
{
    public class InvalidIdException:Exception
    {
        public InvalidIdException():base(ExceptionLiterals.InvalidIdentifier)
        {
            
        }
    }
}
