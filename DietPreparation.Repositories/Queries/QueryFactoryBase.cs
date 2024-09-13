using System.Reflection;

namespace DietPreparation.Repositories.Queries;

public abstract class QueryFactoryBase
{
	protected async Task<string> BuildQuery(string queryName)
	{
		var assemblyPath = GetAssemblyPath();
		var path = Path.Combine(Path.GetDirectoryName(assemblyPath), $"Queries/{queryName}.sql");

		if (File.Exists(path))
		{
			return await ReadStringContentAsync(path);
		}

		throw new InvalidOperationException($"Query file was not found on: {path}");
	}

	protected static string GetAssemblyPath()
	{
		var codeBase = Assembly.GetExecutingAssembly().CodeBase;
		var uri = new UriBuilder(codeBase);
		var assemblyPath = Uri.UnescapeDataString(uri.Path);

		return assemblyPath;
	}

	protected async Task<string> ReadStringContentAsync(string path)
	{
		using var streamReader = new StreamReader(path);
		var content = await streamReader.ReadToEndAsync();

		return content;
	}
}
