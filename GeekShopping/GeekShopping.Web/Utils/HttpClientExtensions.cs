﻿using System.Text.Json;

namespace GeekShopping.Web.Utils
{
	public static class HttpClientExtensions
	{
		public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode) throw
					new ApplicationException(
						$"Algo deu errado chamando a API: " +
						$"{response.ReasonPhrase}"
					);
			var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		}
	}
}
