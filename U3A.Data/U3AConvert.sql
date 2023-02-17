
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
           )
     VALUES
           (newid()
           ,'Eastlakes U3A Inc.'
           ,'Belmont Senior Citizens Centre'
           ,'P.O. Box 455, Belmont NSW 2280'
           ,'7 Glover Street, Belomnt NSW 2280'
           ,'54 792 545 108'
           ,'secretary.eu3a@gmail.com'
           ,'https://eastlakes.u3anet.org.au'
           ,'0490 515 187'
           ,50.00
           ,10.00
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
           )

;WITH Term_CTE (DateDesc, Start, Finish)  
AS  
(  
SELECT SUBSTRING(DateDesc,1,5) DateDesc, Min(TermStart) Start, Max(TermEnd) Finish
		FROM U3AAccess.dbo.TermDates Group By SUBSTRING(DateDesc,1,5)
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
           ,DATEPART(year,Start)
           ,CAST(SUBSTRING ( DateDesc ,5 , 1 )  as int)
		   ,Start
           ,Datediff(wk,Start,Finish)
           ,Datediff(wk,Start,Finish)
           ,-7
	FROM Term_CTE 


INSERT INTO [dbo].[CourseType]
           ([ID]
           ,[Discontinued]
           ,[Name]
           ,[Comment])
SELECT
			newid()
			,0
			,[Course Type]
			,''
FROM U3AAccess.dbo.CourseType WHERE [Course Type] Not in (Select Name from CourseType)

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
           ,[Address]
           ,[Comment]
		   ,MaxNumber)
SELECT
			Newid()
           ,0
           ,Venue
           ,isnull(Address,'')
           ,'Max Numbers: '+ Coalesce(MaxNumbers,'')
		   ,0
FROM U3AAccess.dbo.Venues WHERE Venue + isnull(Address,'') not in (select Name + Address From Venue)

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
		   ,StudentID			ConversionID
           ,FirstName
           ,LastName
           ,isnull(Address,'')
           ,isnull(City,'')
           ,isnull(State,'')
           ,isnull(Postcode,'')
           ,coalesce(Gender,'Other')
           ,null
           ,[StudJoinDate]		DateJoined
           ,null				DtaeCeased
           ,isnull(Email,'')
           ,isnull(Phone,'')	HomePhone
           ,isnull(Mobile,'')
           ,isnull(ICEName,'')				ICEContact
           ,isnull(ICEPhone,'')
           ,isnull(LifeMember,0) IsLifeMember
           ,Covid19
           ,Communication
           ,[CreatedOn] = getDate()
           ,[UpdatedOn] = getDate()
           ,datepart(year,GetDate())
FROM	U3AAccess.dbo.Students 
where StudentID not in (Select ConversionID From Person)
Order By StudentID

IF (@OBFISCATE = 1)
    BEGIN
    UPDATE Person
        SET Mobile = replace(replace(replace(Mobile,'9','8'),'6','3'),'2','5')
            ,HomePhone = replace(replace(replace(HomePhone,'9','8'),'6','3'),'2','5')
            ,ICEPhone = replace(replace(replace(ICEPhone,'9','8'),'6','3'),'2','5')
            ,Postcode = replace(replace(replace(Postcode,'9','8'),'6','3'),'2','5')
            ,Email = lower(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(Email,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski'))
            ,LastName = lower(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(LastName,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski'))
            ,Address = replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(Address,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski')
            ,ICEContact = lower(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ICEContact,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski'))
            ,City = Upper(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(City,'o','e'),'a','o'),'i','a'),'u','i'),'t','p'),'c','k'),'d','th'),'ee','e'),'oo','or'),'ll','ski'))
    UPDATE Person
        SET LastName = UPPER(substring(LastName,1,1)) + RIGHT(LastName,LEN(LastName)-1)
    END

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
		   ,CourseID        ConversionID
           ,CourseName		Name
           ,isnull(ProgramNotes,'')	Description
           ,isnull(Costs,0) CourseFeePerYear
		   ,'' CourseFeePerYearDescription
           ,isnull(Costs,0) CourseFeePerTerm
		   ,'' CourseFeePerTermDescription
           ,isnull(datediff(mi,StartTime,EndTime)/60.00,30) Duration
           ,isnull(ReqdSpaces,0) RequiredStudents
           ,isnull(AvailSpaces,0) MaximumStudents
           ,isnull((Select Top 1 ID From CourseType where Name = CourseType),@KEY) CourseTypeID
           ,0   CourseParticipationTypeID
FROM	U3AAccess.dbo.Courses  where CourseID not in (Select ConversionID From Course)

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
           ,(Select Top 1 ID From Person where Person.Email = LeaderEmail) LeaderID
           ,1 OfferedTerm1
           ,1 OfferedTerm2
           ,1 OfferedTerm3
           ,1 OfferedTerm4
           ,2
           , Case [Day(s)]
				when 'Sunday' then 0
				when 'Monday' then 1
				when 'Tuesday' then 2
				when 'Wednesday' then 3
				when 'Thursday' then 4
				when 'Friday' then 5
				when 'Saturday' then 6
			end  OnDayID
           ,StartTime StartTime
           ,(Select top 1 ID from Course where ConversionID = CourseID) CourseID
           ,(Select Top 1 ID From Venue where Location = Name)   VenueID
FROM	U3AAccess.dbo.Courses			
where	[Day(s)] is not null AND StartTime is not null

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
           ,(select Top 1 ID from Course where Course.ConversionID = c.CourseID)
           ,null
           ,(select Top 1 ID from Person where Person.ConversionID = s.StudentID)
           ,DATETIMEFROMPARTS(DATEPART(year,[Date Entered]), 
                              DATEPART(month,[Date Entered]),
                              DATEPART(day,[Date Entered]),
                              DATEPART(hour,[Time Entered]),
                              DATEPART(minute,[Time Entered])
                              ,DATEPART(second,[Time Entered])
                              ,Cast(rand(checksum(newid()))*1000  as int)) -- !! Important
           ,Isnull(WaitListFlag,0)
           ,null
FROM	U3AAccess.dbo.Registration r Inner Join
			U3AAccess.dbo.Courses c on r.CourseID = c.CourseID inner join
			U3AAccess.dbo.Students s on r.StudentID = s.StudentID

UPDATE Enrolment Set DateEnrolled = Created Where IsWaitlisted = 0
