// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


namespace Aire.Sdk.Azure;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class EntityTableAttribute : Attribute
{
	public string TableName { get; private set; }

	public EntityTableAttribute(string tableName)
	{
		TableName = tableName;
	}
}
