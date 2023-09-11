using Dapper;
using System.Data;
using System.Globalization;

namespace NetCoreShortCodes.API.Repositories.Dapper
{
    public class GuidHandler : SqlMapper.TypeHandler<Guid>
    {
        public override Guid Parse(object value)
        {
            return Guid.Parse((string)value, CultureInfo.InvariantCulture);
        }

        public override void SetValue(IDbDataParameter parameter, Guid value)
        {
            parameter.DbType = DbType.Guid;
            parameter.Value = value;
        }
    }
}