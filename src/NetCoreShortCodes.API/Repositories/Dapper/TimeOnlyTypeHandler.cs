using Dapper;
using System.Data;
using System.Globalization;

namespace NetCoreShortCodes.API.Repositories.Dapper
{
    public class TimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
    {
        public override TimeOnly Parse(object value)
        {
            return TimeOnly.Parse((string)value, CultureInfo.InvariantCulture);
        }

        public override void SetValue(IDbDataParameter parameter, TimeOnly value)
        {
            parameter.DbType = DbType.Time;
            parameter.Value = value;
        }
    }
}