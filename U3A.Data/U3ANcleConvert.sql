
declare @OBFISCATE bit = 0

delete SystemSettings
delete Enrolment
delete Term
delete Class
delete Venue
delete Course
delete CourseType
delete Committee
delete receipt
delete ReceiptDataImport
delete Person
delete AttendanceHistory
delete SendMail


DECLARE @KEY uniqueidentifier
        ,@VKEY uniqueidentifier
        ,@CRLF char(2)

SET @CRLF = char(13) + char(10)

INSERT INTO [dbo].[SystemSettings]
           ([ID]
           ,[U3AGroup]
           ,[OfficeLocation]
           ,[PostalAddress]
           ,[StreetAddress]
           ,[ABN]
           ,[Email]
           ,[Website]
           ,[Phone]
           ,[MembershipFee]
           ,[MailSurcharge]
           ,[RequireVaxCertificate]
           ,[CurrentTermID]
           ,[AutoEnrolNewParticipantPercent]
           ,[AutoEnrolRemainderMethod]
           ,[CommitteePositions]
           ,[VolunteerActivities]
           ,FinancialToMembershipFeePercent
           ,SendEmailAddesss
           ,SendEmailDisplayName
           ,BankBSB
           ,BankAccountNo
           ,[MailLabelBottomMargin]
           ,[MailLabelHeight]
           ,[MailLabelLeftMargin]
           ,[MailLabelRightMargin]
           ,[MailLabelTopMargin]
           ,[MailLabelWidth]
           ,UTCOffset
           )
     VALUES
           (newid()
           ,'Newcastle U3A Inc.'
           ,'Pachamama House'
           ,'P.O. Box 316, Hamilton NSW 2303'
           ,'21 Gordon Avenue, Hamilton NSW 2303'
           ,'' -- ABN Unknown
           ,' newcastleu3a.au@gmail.com'
           ,'https://newcastle.u3anet.org.au/'
           ,'0479 193 182'
           ,60.00
           ,0.00
           ,1
           ,null
           ,15.00
           ,'Random'
           ,'President' 
             + @CRLF + 'Vice-President'
             + @CRLF + 'Secretary'
             + @CRLF + 'Treasurer'
             + @CRLF + 'Assistant Treasurer'
             + @CRLF + 'Course Coordinator'
             + @CRLF + 'Enrolment Officer'
             + @CRLF + 'Venues Officer'
             + @CRLF + 'Leaders Liaison'
             + @CRLF + 'Publicity Officer'
             + @CRLF + 'Assistant Secretary'
             + @CRLF + 'BSCC Convenor'
            ,'Internal Affairs'
                + @CRLF + 'Grounds & Gardening'
                + @CRLF + 'Working Bees'
                + @CRLF + 'Administration'
            ,100.00
            ,'membership@eastlakesu3a.com.au'
            ,'Membership Office'
            ,'650 000'
            ,'822048118'
            ,0
            ,28
            ,7.8
            ,0
            ,10
            ,67.5
            ,10
           )

INSERT INTO [dbo].[Term]
           ([ID]
           ,[Year]
           ,[TermNumber]
           ,[StartDate]
           ,[Duration]
           ,[EnrolmentEnds]
           ,[EnrolmentStarts])
     SELECT
           newid()
           ,[Calendar Year]
           ,1
		   ,[Semester 1 Start]
           ,DateDiff(wk,[Semester 1 Start],[Term 1 Break Start])
           ,Datediff(wk,[Semester 1 Start],[Term 1 Break Start])
           ,-7
	FROM U3ANAccess.dbo.[Semester Dates]

INSERT INTO [dbo].[Term]
           ([ID]
           ,[Year]
           ,[TermNumber]
           ,[StartDate]
           ,[Duration]
           ,[EnrolmentEnds]
           ,[EnrolmentStarts])
     SELECT
           newid()
           ,[Calendar Year]
           ,2
		   ,[Term 1 Break End]
           ,DateDiff(wk,[Term 1 Break End],[Semester 1 End])
           ,Datediff(wk,[Term 1 Break End],[Semester 1 End])
           ,-7
	FROM U3ANAccess.dbo.[Semester Dates]

INSERT INTO [dbo].[Term]
           ([ID]
           ,[Year]
           ,[TermNumber]
           ,[StartDate]
           ,[Duration]
           ,[EnrolmentEnds]
           ,[EnrolmentStarts])
     SELECT
           newid()
           ,[Calendar Year]
           ,3
		   ,[Semester 2 Start]
           ,DateDiff(wk,[Semester 2 Start],[Term 2 Break Start])
           ,Datediff(wk,[Semester 2 Start],[Term 2 Break Start])
           ,-7
	FROM U3ANAccess.dbo.[Semester Dates]

INSERT INTO [dbo].[Term]
           ([ID]
           ,[Year]
           ,[TermNumber]
           ,[StartDate]
           ,[Duration]
           ,[EnrolmentEnds]
           ,[EnrolmentStarts])
     SELECT
           newid()
           ,[Calendar Year]
           ,4
		   ,[Term 2 Break End]
           ,DateDiff(wk,[Term 2 Break End],[Semester 2 End])
           ,Datediff(wk,[Term 2 Break End],[Semester 2 End])
           ,-7
	FROM U3ANAccess.dbo.[Semester Dates]


INSERT INTO [dbo].[CourseType]
           ([ID]
           ,[Discontinued]
           ,[Name]
           ,[Comment])
SELECT
			newid()
			,0
			,[Category]
			,''
FROM U3ANAccess.dbo.Category

SET @KEY = newid()
INSERT INTO [dbo].[CourseType]
           ([ID]
           ,[Discontinued]
           ,[Name]
           ,[Comment])
SELECT
			@KEY
			,1
			,'? Unknown ?'
			,''

INSERT INTO [dbo].[Venue]
           ([ID]
           ,[Discontinued]
           ,[Name]
           ,[MaxNumber]
           ,[Address]
           ,[Comment]
           ,[AccessDetail]
           ,[Coordinator]
           ,[Email]
           ,[Equipment]
           ,[KeyCode]
           ,[Phone])
     SELECT
			Newid()
           ,0
           ,(select top 1 value FROM STRING_SPLIT(Location,','))
           ,isnull(Limit,0)
           ,(SELECT REPLACE(SUBSTRING([Location], CHARINDEX(',', [Location]), LEN([Location])), ',', ''))
		   ,isnull(Comment,'')
           ,[Entry Access]
           ,[Venue Coordinator]
           ,[Coordinator e-mail]
           ,Equipment
           ,[key access]
           ,[Coordinator Phone]
FROM U3ANAccess.dbo.Venue

SET @VKEY = newid()
INSERT INTO [dbo].[Venue]
           ([ID]
           ,[Discontinued]
           ,[Name]
           ,[MaxNumber]
           ,[Address]
           ,[Comment]
           ,[AccessDetail]
           ,[Coordinator]
           ,[Email]
           ,[Equipment]
           ,[KeyCode]
           ,[Phone])
     SELECT
			@VKEY
           ,0
           ,'? Unknown ?'
           ,0
           ,''
		   ,''
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''



INSERT INTO [dbo].[Person]
           ([ID]
		   ,[ConversionID]
           ,[FirstName]
           ,[LastName]
           ,[Address]
           ,[City]
           ,[State]
           ,[Postcode]
           ,[Gender]
           ,[BirthDate]
           ,[DateJoined]
           ,[DateCeased]
           ,[Email]
           ,[HomePhone]
           ,[Mobile]
           ,[ICEContact]
           ,[ICEPhone]
           ,[IsLifeMember]
           ,[VaxCertificateViewed]
           ,[Communication]
           ,[CreatedOn]
           ,[UpdatedOn]
           ,[FinancialTo]
           )
     SELECT
           newid()				ID
		   ,Membership_ID			ConversionID
           ,[First Name]
           ,Surname
           ,isnull([Street Address],'')
           ,s.Suburb
           ,'NSW'
           ,s.PostCode
           ,''
           ,null
           ,cast('1-jan-2022' as Datetime)		DateJoined
           ,null				DtaeCeased
           ,isnull([e-mail Address],'')
           ,isnull([Phone Number],'')	HomePhone
           ,isnull([Mobile Number],'')
           ,'To be advised'				ICEContact
           ,'Unknown'              ICEPhone
           ,0 IsLifeMember
           ,0 Covid19
           ,case
                when trim(isnull([e-mail address],'')) = '' then 'Post'
                else 'Email'
            end as Communication
           ,[CreatedOn] = getDate()
           ,[UpdatedOn] = getDate()
           ,datepart(year,GetDate())
FROM	U3ANAccess.dbo.Membership inner join U3ANAccess.dbo.Suburb s
        on U3ANAccess.dbo.Membership.Suburb = s.ID

--IF (@OBFISCATE = 1)
--    BEGIN
--    UPDATE Person
--        SET Mobile = replace(replace(replace(Mobile,'9','8'),'6','3'),'2','5')
--            ,HomePhone = replace(replace(replace(HomePhone,'9','8'),'6','3'),'2','5')
--            ,ICEPhone = replace(replace(replace(ICEPhone,'9','8'),'6','3'),'2','5')
--            ,Postcode = replace(replace(replace(Postcode,'9','8'),'6','3'),'2','5')
--            ,Email = lower(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(Email,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski'))
--            ,LastName = lower(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(LastName,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski'))
--            ,Address = replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(Address,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski')
--            ,ICEContact = lower(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ICEContact,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski'))
--            ,City = Upper(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(City,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski'))
--    UPDATE Person
--        SET LastName = UPPER(substring(LastName,1,1)) + RIGHT(LastName,LEN(LastName)-1)
--    END

update U3ANAccess.dbo.[Time]
        set Time = '0:00 am' where time = 'tbastart'
update U3ANAccess.dbo.[Time]
        set Time = '1:00 am' where time = 'tbafin'
update U3ANAccess.dbo.[Time]
        set Time = '12:00 pm' where time = '12 noon'

INSERT INTO [dbo].[Course]
           ([ID]
		   ,[ConversionID]
           ,[Name]
           ,[Description]
           ,[CourseFeePerYear]
		   ,[CourseFeePerYearDescription]
           ,[CourseFeePerTerm]
		   ,[CourseFeePerTermDescription]
           ,[Duration]
           ,[RequiredStudents]
           ,[MaximumStudents]
           ,[CourseTypeID]
           ,[CourseParticipationTypeID])
     SELECT
           newid()			ID
		   ,[Code Programme]        ConversionID
           ,[Title of Course]		Name
           ,isnull([Description],'')	Description
           ,isnull(Cost,0) CourseFeePerYear
		   ,'' CourseFeePerYearDescription
           ,isnull(Cost,0) CourseFeePerTerm
		   ,'' CourseFeePerTermDescription
           ,isnull(datediff(mi,
                        (select top 1 cast([time] as datetime) from U3ANAccess.dbo.[Time] T where T.ID = [Time ( Start )])   
                        ,(select top 1 cast([time] as datetime) from U3ANAccess.dbo.[Time] T where T.ID = [Time ( Finish )]))/60.00,30) Duration
           ,isnull([Minimum in Class],0) RequiredStudents
           ,isnull([Class Limit],0) MaximumStudents
           ,isnull((Select Top 1 ID From CourseType where Name = (select top 1 Category From U3ANAccess.dbo.Category C Where U3ANAccess.dbo.Programme.Category = c.ID)),@KEY) CourseTypeID
           ,0   CourseParticipationTypeID
FROM	U3ANAccess.dbo.Programme

INSERT INTO [dbo].[Class]
           ([ID]
           ,[LeaderID]
           ,[OfferedTerm1]
           ,[OfferedTerm2]
           ,[OfferedTerm3]
           ,[OfferedTerm4]
           ,[OccurrenceID]
           ,[OnDayID]
           ,[StartTime]
           ,[CourseID]
           ,[VenueID])
SELECT
           newid()	ID
           ,(Select Top 1 ID From Person where Person.ConversionID = [Course Leader A]) LeaderID
           ,1 OfferedTerm1
           ,1 OfferedTerm2
           ,1 OfferedTerm3
           ,1 OfferedTerm4
           ,2
           ,case
                when [Day of Week] <= 6 then [Day of Week]
                else 0
            end as OnDayID
           ,(select top 1 cast([time] as datetime) from U3ANAccess.dbo.[Time] T where T.ID = [Time ( Start )]) StartTime
           ,(Select top 1 ID from Course where ConversionID = [Code Programme]) CourseID
           ,isnull((Select Top 1 ID From Venue where Name = 
                            (select top 1 (select top 1 value FROM STRING_SPLIT(Location,',')) from U3ANAccess.dbo.Venue v where v.ID = U3ANAccess.dbo.Programme.Venue )),@VKEY)   VenueID
FROM	U3ANAccess.dbo.Programme

-- Normalise StartTime to 1st Jan 0001 so we have no sort issues

update class
	set StartTime = DateAdd(year,(datepart(year,StartTime)-1)*-1,StartTime)
where DATEPART(year,StartTime) > 1
update class
	set StartTime = DateAdd(month,(datepart(month,StartTime)-1)*-1,StartTime)
where DATEPART(month,StartTime) > 1
update class
	set StartTime = DateAdd(day,(datepart(day,StartTime)-1)*-1,StartTime)
where DATEPART(day,StartTime) > 1

INSERT INTO [dbo].[Enrolment]
           ([ID]
           ,[TermID]
           ,[CourseID]
           ,[ClassID]
           ,[PersonID]
           ,[Created]
           ,[IsWaitlisted]
           ,[DateEnrolled])
     SELECT
           newid()
           ,(Select Top 1 ID from Term Order by Year desc, TermNumber desc)
           ,(select Top 1 ID from Course where Course.ConversionID = p.[Code Programme])
           ,null
           ,(select Top 1 ID from Person where Person.ConversionID = m.Membership_ID)
           ,DATETIMEFROMPARTS(DATEPART(year,[Enrol Date]), 
                              DATEPART(month,[Enrol Date]),
                              DATEPART(day,[Enrol Date]),
                              DATEPART(hour,[Enrol Date]),
                              DATEPART(minute,[Enrol Date])
                              ,DATEPART(second,[Enrol Date])
                              ,Cast(rand(checksum(newid()))*1000  as int)) -- !! Important
           ,Isnull([WaitListed ?],0)
           ,null
FROM	U3ANAccess.dbo.Enrolment e Inner Join
			U3ANAccess.dbo.Programme p on e.[Programme Code] = p.[Code Programme] inner join
			U3ANAccess.dbo.Membership m on e.[Membership ID] = m.Membership_ID

UPDATE Enrolment Set DateEnrolled = Created Where IsWaitlisted = 0
