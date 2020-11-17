﻿using AReport.Support.Common;
using AReport.Support.Interface;
using System;


namespace AReport.Support.Entity
{
    /*
     CREATE TABLE [dbo].[Checkinout](
	    [Logid] [int] IDENTITY(1,1) NOT NULL,
	    [Userid] [varchar](20) NOT NULL,
	    [CheckTime] [datetime] NOT NULL,
	    [CheckType] [int] NOT NULL,
	..
     */

    [Serializable]
    public class Checkinout : IEntityStatus
    {
        public EntityState Status
        { get; set; }

        public int LogId
        { get; set; }

        public string UserId
        { get; set; }

        public DateTime CheckTime
        { get; set; }

        public int CheckType
        { get; set; }
    }
}