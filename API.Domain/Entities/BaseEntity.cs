using System.Runtime.CompilerServices;

namespace APP.Domain.Entities
{
    public class BaseEntity : ChannelBase
    {
        public virtual int? Id { get; set; }
    }

    public class ChannelBase
    {
        public String? ChannelType { get; set; }

    }
}
