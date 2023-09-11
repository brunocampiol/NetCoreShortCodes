using Dapper;
using System.Data;
using System.Globalization;

namespace NetCoreShortCodes.API.Repositories.Dapper
{
    public class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        public override DateOnly Parse(object value)
        {
            return DateOnly.Parse((string)value, CultureInfo.InvariantCulture);
        }

        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = value;
        }
    }
}