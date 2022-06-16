using System.Reflection;
namespace Application.Mappings;

public static class PatchRequestMap
{
	public static T PatchMap<T, T1>(T origin, T1 dto)
	{
		var copy = origin;
		foreach (PropertyInfo prop in copy.GetType().GetProperties())
		{
			var propName = prop.Name;
			var DtoProp = dto.GetType().GetProperty(propName);
			if (DtoProp != null)
			{
				var DtoPropName = DtoProp.Name;
				var DtoPropValue = DtoProp.GetValue(dto, null);
				if (DtoPropValue != null)
				{
					origin.GetType().GetProperty(DtoPropName).SetValue(origin, DtoPropValue);
				}
			}

		}
		return copy;
	}
}

