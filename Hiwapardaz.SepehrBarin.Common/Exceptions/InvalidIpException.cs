using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Common.Literals;

namespace Hiwapardaz.SepehrBarin.Common.Exceptions
{
    public class InvalidIpException:Exception
    {
        public InvalidIpException(string ip)
            :base(string.Format(ExceptionLiterals.InvalidIp)) 
        {
            ip.NotNull();
        }
    }
}
