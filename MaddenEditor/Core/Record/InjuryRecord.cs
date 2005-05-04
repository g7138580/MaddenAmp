/******************************************************************************
 * Madden 2005 Editor
 * Copyright (C) 2005 Colin Goudie
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 * 
 * http://gommo.homelinux.net/index.php/Projects/MaddenEditor
 * 
 * colin.goudie@gmail.com
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace MaddenEditor.Core.Record
{
	public class InjuryRecord : TableRecordModel
	{
		public const string INJURY_LENGTH = "INJL";
		public const string INJURY_TYPE = "INJT";
		public const string PLAYER_ID = "PGID";
		public const string TEAM_ID = "TGID";
		public const string INJURY_RSV = "INIR";

		public InjuryRecord(int record, EditorModel EditorModel)	: base(record, EditorModel)
		{

		}

		public int InjuryLength
		{
			get
			{
				return intFields[INJURY_LENGTH];
			}
			set
			{
				SetFieldWithBackup(INJURY_LENGTH, value);
			}
		}

		public int InjuryType
		{
			get
			{
				return (intFields[INJURY_TYPE] < 230 ? intFields[INJURY_TYPE] : 229);
			}
			set
			{
				SetFieldWithBackup(INJURY_TYPE, value);
			}
		}

		public int PlayerId
		{
			get
			{
				return intFields[PLAYER_ID];
			}
			set
			{
				SetFieldWithBackup(PLAYER_ID, value);
			}
		}

		public int TeamId
		{
			get
			{
				return intFields[TEAM_ID];
			}
			set
			{
				SetFieldWithBackup(TEAM_ID, value);
			}
		}

		public bool InjuryReserve
		{
			get
			{
				return (intFields[INJURY_RSV] == 1);
			}
			set
			{
				SetFieldWithBackup(INJURY_RSV, Convert.ToInt32(value));
			}
		}

		public String LengthDescription
		{
			get
			{
				int length = intFields[INJURY_LENGTH]%256;

				if (length == 0)
				{
					return "Ready To Play";
				}
				else if ((length >= 1 && length <= 9) || (length >= 257 && length <= 265))
				{
					return "Doubtful";
				}
				else if (length >= 10 && length <= 19)
				{
					return "Will return soon";
				}
				else if (length == 20)
				{
					return "1 quarter";
				}
				else if (length == 21)
				{
					return "2 quarters";
				}
				else if (length == 22)
				{
					return "3 quarters";
				}
				else if (length == 23)
				{
					return "Out for game";
				}
				else if (length >= 24 && length <= 243)
				{
					return (((length - 24)/20) + 1) + " week/s";
				}
				else if (length >= 244 && length <= 254)
				{
					return "12 weeks";
				}
				else if (length == 254)
				{
					return "Out for season";
				}
				else if (length == 255)
				{
					return "Career ending";
				}
				return "";
			}
		}
	}
}
