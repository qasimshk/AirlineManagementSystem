using airline.flightdetail.api.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace airline.flightdetail.api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IDbConnection _db;

        public CountryRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CountryDetailsDto>> Get()
        {
            return await _db.QueryAsync<CountryDetailsDto>("SELECT CountryName, CountryCode FROM Country", commandType: CommandType.Text);
        }
    }
}
