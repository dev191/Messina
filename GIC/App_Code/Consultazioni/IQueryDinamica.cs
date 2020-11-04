using System;
using System.Data;

namespace GIC.App_Code.Consultazioni
{
	 interface IQueryDinamica
	{
		 DataSet GetData(int IdQuery);
	}
}
