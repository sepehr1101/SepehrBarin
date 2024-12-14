using Hiwapardaz.SepehrBarin.Common.Literals;

namespace Hiwapardaz.SepehrBarin.Common.Exceptions
{
    public class RootProjectNotFoundException:Exception       
    {
        public RootProjectNotFoundException(string applicationBasePath)
            :base($"{ExceptionLiterals.AppBasePathNotFound_1} {applicationBasePath}")
        {
            
        }
    }
}
