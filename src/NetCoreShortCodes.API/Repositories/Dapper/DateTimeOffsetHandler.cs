using Dapper;
using System.Data;
using System.Globalization;

namespace NetCoreShortCodes.API.Repositories.Dapper
{
    public class DateTimeOffsetHandler : SqlMapper.TypeHandler<DateTimeOffset>
    {
        public override DateTimeOffset Parse(object value)
        {
            return DateTimeOffset.Parse((string)value, CultureInfo.InvariantCulture);
        }

        public override void SetValue(IDbDataParameter parameter, DateTimeOffset value)
        {
            parameter.DbType = DbType.DateTimeOffset;
            parameter.Value = value;
        }
    }
}
