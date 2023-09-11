using Dapper;
using System.Data;
using System.Globalization;

namespace NetCoreShortCodes.API.Repositories.Dapper
{
    public class TimeSpanHandler : SqlMapper.TypeHandler<TimeSpan>
    {
        public override TimeSpan Parse(object value)
        {
            return TimeSpan.Parse((string)value, CultureInfo.InvariantCulture);
        }

        public override void SetValue(IDbDataParameter parameter, TimeSpan value)
        {
            parameter.DbType = DbType.Guid;
            parameter.Value = value;
        }
    }
}