//
// StringConstructor.cs:
//
// Author: Cesar Octavio Lopez Nataren
//
// (C) 2003, Cesar Octavio Lopez Nataren, <cesar@ciencias.unam.mx>
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

namespace Microsoft.JScript {

	public class StringConstructor : ScriptFunction {

		internal static StringConstructor Ctr = new StringConstructor ();

		internal StringConstructor ()
		{
		}

		[JSFunctionAttribute (JSFunctionAttributeEnum.HasVarArgs)]
		public new StringObject CreateInstance (params Object [] args)
		{
			if (args == null || args.Length == 0)
				return new StringObject ();

			object tmp = args [0];

			if (tmp == null)
				return new StringObject ("undefined");

			IConvertible ic = tmp as IConvertible;			       
			TypeCode tc = ic.GetTypeCode ();

			switch (tc) {
			case TypeCode.Empty:
				return new StringObject ("null");
			case TypeCode.Double:
			case TypeCode.String:
				return new StringObject (ic.ToString (null));
			case TypeCode.DBNull:
				return new StringObject ("null");
			default:
				Console.WriteLine ("tc = {0}", tc);
				throw new Exception ("unknown TypeCode");
			}
		}


		public string Invoke (Object arg)
		{
			throw new NotImplementedException ();
		}

		[JSFunctionAttribute (JSFunctionAttributeEnum.HasVarArgs, JSBuiltin.String_fromCharCode)]
		public static String fromCharCode (params Object [] args)
		{
			throw new NotImplementedException ();
		}
	}
}
