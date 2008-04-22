﻿/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

    FFTPatcher is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    FFTPatcher is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with FFTPatcher.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FFTPatcher.TextEditor
{
    public partial class CharmapForm : Form
    {

		#region Static Fields (2) 

        private static GenericCharMap currentCharMap = null;
        private static CharmapForm instance = null;

		#endregion Static Fields 

		#region Static Properties (1) 


        private static CharmapForm Instance
        {
            get
            {
                if( instance == null )
                {
                    instance = new CharmapForm();
                }

                return instance;
            }
        }


		#endregion Static Properties 

		#region Constructors (1) 

        private CharmapForm()
        {
            InitializeComponent();
            textBox.Font = new Font( "Arial Unicode MS", 10 );
            textBox.Enter += textBox_Enter;
        }

		#endregion Constructors 

		#region Methods (3) 


        private static void SetCharMap( GenericCharMap map )
        {
            List<string> keys = new List<string>( map.Reverse.Keys );
            keys.Sort();
            keys.RemoveAll(
                delegate( string s )
                {
                    return s.Contains( @"{Delay " ) || s.Contains( @"{Tab " ) || s.Contains( @"{Color " );
                } );
            Instance.textBox.Text = string.Join( "\r\n", keys.ToArray() );
            currentCharMap = map;
        }

        private void textBox_Enter( object sender, System.EventArgs e )
        {
            textBox.Select( 0, 0 );
        }

        public static void Show( GenericCharMap charmap )
        {
            if( currentCharMap != charmap )
            {
                SetCharMap( charmap );
            }

            Instance.Show();
        }


		#endregion Methods 

    }
}
