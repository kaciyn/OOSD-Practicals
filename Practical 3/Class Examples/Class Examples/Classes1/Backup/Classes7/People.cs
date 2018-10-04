using System;

namespace Classes7
{
	/// <summary>
	/// Summary description for People.
	/// </summary>
	public class People
	{
		private string name;
		public string Name 
		{
			get {return name;}
			set {name=value;}
		}
		public void ToLowerCase() 
		{
			name=name.ToLower();
		}
	}
}
