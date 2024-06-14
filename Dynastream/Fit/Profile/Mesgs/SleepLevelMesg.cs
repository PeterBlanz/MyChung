#region Copyright
/////////////////////////////////////////////////////////////////////////////////////////////
// Copyright 2024 Garmin International, Inc.
// Licensed under the Flexible and Interoperable Data Transfer (FIT) Protocol License; you
// may not use this file except in compliance with the Flexible and Interoperable Data
// Transfer (FIT) Protocol License.
/////////////////////////////////////////////////////////////////////////////////////////////
// ****WARNING****  This file is auto-generated!  Do NOT edit this file.
// Profile Version = 21.141.0Release
// Tag = production/release/21.141.0-0-g2aa27e1
/////////////////////////////////////////////////////////////////////////////////////////////

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Linq;

namespace Dynastream.Fit
{
    /// <summary>
    /// Implements the SleepLevel profile message.
    /// </summary>
    public class SleepLevelMesg : Mesg
    {
        #region Fields
        #endregion

        /// <summary>
        /// Field Numbers for <see cref="SleepLevelMesg"/>
        /// </summary>
        public sealed class FieldDefNum
        {
            public const byte Timestamp = 253;
            public const byte SleepLevel = 0;
            public const byte Invalid = Fit.FieldNumInvalid;
        }

        #region Constructors
        public SleepLevelMesg() : base(Profile.GetMesg(MesgNum.SleepLevel))
        {
        }

        public SleepLevelMesg(Mesg mesg) : base(mesg)
        {
        }
        #endregion // Constructors

        #region Methods
        ///<summary>
        /// Retrieves the Timestamp field
        /// Units: s</summary>
        /// <returns>Returns DateTime representing the Timestamp field</returns>
        public DateTime GetTimestamp()
        {
            Object val = GetFieldValue(253, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return TimestampToDateTime(Convert.ToUInt32(val));
            
        }

        /// <summary>
        /// Set Timestamp field
        /// Units: s</summary>
        /// <param name="timestamp_">Nullable field value to be set</param>
        public void SetTimestamp(DateTime timestamp_)
        {
            SetFieldValue(253, 0, timestamp_.GetTimeStamp(), Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the SleepLevel field</summary>
        /// <returns>Returns nullable SleepLevel enum representing the SleepLevel field</returns>
        public SleepLevel? GetSleepLevel()
        {
            object obj = GetFieldValue(0, 0, Fit.SubfieldIndexMainField);
            SleepLevel? value = obj == null ? (SleepLevel?)null : (SleepLevel)obj;
            return value;
        }

        /// <summary>
        /// Set SleepLevel field</summary>
        /// <param name="sleepLevel_">Nullable field value to be set</param>
        public void SetSleepLevel(SleepLevel? sleepLevel_)
        {
            SetFieldValue(0, 0, sleepLevel_, Fit.SubfieldIndexMainField);
        }
        
        #endregion // Methods
    } // Class
} // namespace
