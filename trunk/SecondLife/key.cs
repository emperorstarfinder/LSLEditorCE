// /**
// ********
// *
// * ORIGIONAL CODE BASE IS Copyright (C) 2006-2010 by Alphons van der Heijden
// * The code was donated on 4/28/2010 by Alphons van der Heijden
// * To Brandon'Dimentox Travanti' Husbands & Malcolm J. Kudra which in turn Liscense under the GPLv2.
// * In agreement to Alphons van der Heijden wishes.
// *
// * The community would like to thank Alphons for all of his hard work, blood sweat and tears.
// * Without his work the community would be stuck with crappy editors.
// *
// * The source code in this file ("Source Code") is provided by The LSLEditor Group
// * to you under the terms of the GNU General Public License, version 2.0
// * ("GPL"), unless you have obtained a separate licensing agreement
// * ("Other License"), formally executed by you and The LSLEditor Group.  Terms of
// * the GPL can be found in the gplv2.txt document.
// *
// ********
// * GPLv2 Header
// ********
// * LSLEditor, a External editor for the LSL Language.
// * Copyright (C) 2010 The LSLEditor Group.
// 
// * This program is free software; you can redistribute it and/or
// * modify it under the terms of the GNU General Public License
// * as published by the Free Software Foundation; either version 2
// * of the License, or (at your option) any later version.
// *
// * This program is distributed in the hope that it will be useful,
// * but WITHOUT ANY WARRANTY; without even the implied warranty of
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// * GNU General Public License for more details.
// *
// * You should have received a copy of the GNU General Public License
// * along with this program; if not, write to the Free Software
// * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// ********
// *
// * The above copyright notice and this permission notice shall be included in all 
// * copies or substantial portions of the Software.
// *
// ********
// */
using System;

namespace LSLEditor
{
	public partial class SecondLife
	{
		public struct key
		{
			private string m_value;

			public string guid
			{
				get
				{
					if (m_value == null)
						m_value = "";
					return m_value;
				}
				set
				{
					m_value = value;
				}
			}

			public key(Guid guid)
			{
				this.m_value = guid.ToString();
			}

			public key(string strGuid)
			{
				this.m_value = strGuid;
			}

			public static readonly key NULL_KEY;
			static key()
			{
				NULL_KEY = new key("00000000-0000-0000-0000-000000000000");
			}

			// This is the one-and-only implicit typecasting in SecondLife
			public static implicit operator key(string strGuid)
			{
				if (strGuid == null)
					return new key("");
				else
					return new key(strGuid);
			}

			public static implicit operator key(String _strGuid)
			{
				string strGuid = _strGuid;
				if (strGuid == null)
					return new key("");
				else
					return new key(strGuid);
			}

			public override string ToString()
			{
				if (this.guid == null)
					this.guid = "";
				return this.guid.ToString();
			}

			//public static explicit operator String(key k)
			//{
			//	return k.ToString();
			//}

			// Check this!!!!
			public static implicit operator String(key k)
			{
				return k.ToString();
			}

			public static bool operator ==(key key1, key key2)
			{
				return (key1.guid == key2.guid);
			}

			public static bool operator !=(key key1, key key2)
			{
				return !(key1.guid == key2.guid);
			}

			public static bool operator true(key k)
			{
				if ((object)k == null)
					return false;
				if (k.guid == NULL_KEY)
					return false;
				if (k.guid == "")
					return false;
				return true;
			}

			public static bool operator false(key k)
			{
				if ((object)k == null)
					return true;
				if (k.guid == NULL_KEY)
					return true;
				if (k.guid == "")
					return true;
				return false;
			}

			public override bool Equals(object obj)
			{
				try
				{
					return (this == (key)obj);
				}
				catch
				{
					return false;
				}
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
		}
	}
}
