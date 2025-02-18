Use QPPlatformManagerDB
GO


IF EXISTS(SELECT * FROM dbo.SYSOBJECTS WHERE OBJECT_ID('f_GetAgentWaste')=id AND xtype='FN')
	DROP FUNCTION f_GetFormatDate_CN
GO
CREATE FUNCTION f_GetFormatDate_CN(
	@date VARCHAR(100)
)
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @outputdate VARCHAR(100)
	SET @outputdate= CONVERT(VARCHAR(10),YEAR(@date))+'年'+CONVERT(VARCHAR(10),MONTH(@date))+'月'+CONVERT(VARCHAR(10),DAY(@date))+'日'
	RETURN @outputdate
END

GO


/*
	玩家返利记录明细
	结果集说明：
	 UserID：           --玩家ID
	 SpreadDate			--返利日期
	 SpreadUserID			--推广玩家的UserID
	 SpreadGameID			--推广玩家的GameID
	 SpreadSum			--返利金币
	 SpreadType			--0为直接推广，1为间接推广
*/
IF EXISTS(SELECT * FROM dbo.SysObjects WHERE OBJECT_ID('p_GetChildrenSpreadSum_ByUserID')=id AND type='P')
	DROP PROC p_GetChildrenSpreadSum_ByUserID
GO
CREATE PROC p_GetChildrenSpreadSum_ByUserID
	@UserID INT,
	@pageIndex INT=1,
	@pageSize INT=20
AS
DECLARE @SQL VARCHAR(MAX)=''
DECLARE @tempTable VARCHAR(50)=''
SET @tempTable = Replace('##'+CONVERT(VARCHAR(50), NEWID()),'-','')

SET @SQL='
SELECT a.[UserID],dbo.f_GetFormatDate_CN(a.SpreadDate) SpreadDate,b.UserID SpreadUserID,ai.GameID SpreadGameID,b.SpreadSum,ROW_NUMBER() OVER(ORDER BY SpreadDate DESC) RowNo,
CASE WHEN b.UserID='+CONVERT(VARCHAR(100),@UserID)+' OR EXISTS(SELECT 1 FROM QPAccountsDB.dbo.AccountsInfo c WHERE c.UserID=b.UserID AND c.SpreaderID='+CONVERT(VARCHAR(100),@UserID)+') THEN 0 ELSE 1 END  SpreadType
INTO '+@tempTable+'
FROM [QPPlatformManagerDB].[dbo].[RecordSpreadSum] a
INNER JOIN [QPPlatformManagerDB].[dbo].[RecordSpreadSumDetail] b ON a.ID=b.RecordSpreadSumID
INNER JOIN QPAccountsDB.dbo.AccountsInfo ai ON b.UserID=ai.UserID
WHERE a.UserID='+CONVERT(VARCHAR(100),@UserID)+'
AND a.SpreadSum<>0

SELECT totalCount=COUNT(1) FROM '+@tempTable+'

SELECT * FROM '+@tempTable+'
WHERE RowNo BETWEEN '+CONVERT(VARCHAR(50),(@pageIndex-1)*@pageSize)+' AND '+CONVERT(VARCHAR(50),@pageIndex*@pageSize)

EXEC(@SQL)
GO


