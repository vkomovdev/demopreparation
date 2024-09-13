using Dapper;
using DietPreparation.Utilities.ExceptionHandler;
using System.Data;
using System.Data.Common;

namespace DietPreparation.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private readonly DbConnection _connection;

	private DbTransaction? _transaction;

	public UnitOfWork(DbConnection connection)
	{
		_connection = connection;

		Connect(connection);
	}

	public DbConnection Connection => _connection;
	public DbTransaction? Transaction => _transaction;

	public void Begin()
	{
		_transaction = _connection.BeginTransaction();
	}

	public async Task BeginAsync()
	{
		_transaction = await _connection.BeginTransactionAsync();
	}

	public void Commit()
	{
		_transaction?.Commit();
	}

	public async Task CommitAsync()
	{
		if (_transaction != null)
		{
			await _transaction.CommitAsync();
		}
	}

	public void Dispose()
	{
		if (_transaction != null)
		{
			_transaction.Dispose();
			_transaction = null;
		}

		_connection?.Dispose();
	}

	public void Rollback()
	{
		_transaction?.Rollback();
	}

	public async Task RollbackAsync()
	{
		if (_transaction != null)
		{
			await _transaction.RollbackAsync();
		}
	}

	private static void Connect(IDbConnection connection)
	{
		try
		{
			connection.Open();
		}
		catch (Exception exception)
		{
			throw new DietPreparationException(CommonErrorCode.DatabaseConnectionException, exception);
		}
	}

	public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
	{
		return await _connection.QueryAsync<T>(sql, param, _transaction);
	}

	public async Task<T> QuerySingleAsync<T>(string sql, object? param = null)
	{
		return await _connection.QuerySingleAsync<T>(sql, param, _transaction);
	}

	public async Task<dynamic> QuerySingleAsync(string sql, object? param = null)
	{
		return await _connection.QuerySingleAsync(sql, param, _transaction);
	}

	public async Task<T> QueryFirstAsync<T>(string sql, object? param = null)
	{
		return await _connection.QueryFirstAsync<T>(sql, param, _transaction);
	}

	public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null)
	{
		return await _connection.QueryFirstOrDefaultAsync<T>(sql, param, _transaction);
	}

	public async Task<int> ExecuteAsync(string sql, object? param = null)
	{
		return await _connection.ExecuteAsync(sql, param, _transaction);
	}
}