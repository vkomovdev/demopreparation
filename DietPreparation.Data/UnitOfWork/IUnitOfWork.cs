using System.Data.Common;

namespace DietPreparation.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
	DbConnection Connection { get; }
	DbTransaction? Transaction { get; }
	void Begin();
	void Commit();
	void Rollback();
	Task BeginAsync();
	Task CommitAsync();
	Task RollbackAsync();

	Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null);
	Task<T> QuerySingleAsync<T>(string sql, object? param = null);
	Task<dynamic> QuerySingleAsync(string sql, object? param = null);
	Task<T> QueryFirstAsync<T>(string sql, object? param = null);
	Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null);
	Task<int> ExecuteAsync(string sql, object? param = null);
}