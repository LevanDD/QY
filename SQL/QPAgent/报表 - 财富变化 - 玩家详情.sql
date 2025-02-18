USE QPTreasureDB
GO

-----------统计数据 - 财富变化
IF EXISTS(SELECT * FROM dbo.SysObjects WHERE OBJECT_ID('p_Report_GetRichChange')=id AND xtype='P')
	DROP PROC p_Report_GetRichChange
GO
CREATE PROC p_Report_GetRichChange
	@rType INT,	
	@startDate VARCHAR(30),
	@endDate VARCHAR(30),
	@byUserID INT,
	@userType VARCHAR(10),
	@pageIndex INT=1,
	@pageSize INT=20
AS
BEGIN
	DECLARE @SQL VARCHAR(MAX)=''
	DECLARE @Where VARCHAR(1000)=''
	DECLARE @tempTable VARCHAR(50)=''
	SET @tempTable = Replace('##'+CONVERT(VARCHAR(50), NEWID()),'-','')

	--条件
	IF @byUserID<>'' 
	BEGIN
	SET @Where=@Where+' AND s.UserID='+CONVERT(VARCHAR(15),@byUserID)
	END 

	IF @rType<>-1
	BEGIN
		IF @rType=1
		BEGIN
			SET @Where=@Where+' AND s.Reason IN (0,1)'
		END
		ELSE
		BEGIN
			SET @Where=@Where+' AND s.Reason='+CONVERT(VARCHAR(30),@rType)
		END
	END
	IF @startDate<>''
		SET @Where=@Where+' AND s.LastTime >= '''+@startDate+''''
	IF @endDate<>''
		SET @Where=@Where+' AND s.LastTime < '''+@endDate+'  23:59:59'''

	--玩家游戏记录
	SET @SQL='
	SELECT DISTINCT s.UserID,s.LastTime RecordTime,CASE WHEN s.Reason IN (0,1) THEN ''普通游戏'' WHEN s.Reason=2 THEN ''购买/兑换'' WHEN s.Reason=3 THEN ''充值'' WHEN s.Reason=4 THEN ''每日幸运转盘抽取'' WHEN s.Reason=5 THEN ''邮件附件领取'' WHEN s.Reason=6 THEN ''每日签到'' WHEN s.Reason=7 THEN ''赠送'' WHEN s.Reason=8 THEN ''存款'' WHEN s.Reason=9 THEN ''取款'' END [Type],
	''服务'' RType,g.GameName Game,IsNull(s.BeforeScore,0) BeforeScore,IsNull(s.ChangeScore,0) ChangeScore,IsNull(s.AfterScore,0) AfterScore,IsNull(s.Revenue,0) Revenue,r.ServerName Room,
	a.UserID,a.GameID , a.Accounts,a.NickName,ROW_NUMBER() OVER(ORDER BY s.LastTime DESC) RowNo
	INTO '+@tempTable+'
	FROM [QPRecordDB].[dbo].[RecordRichChange] s
	INNER JOIN QPAccountsDB.dbo.AccountsInfo a ON a.IsAndroid=0 AND s.UserID=a.UserID
	LEFT JOIN [QPPlatformDB].[dbo].[GameRoomInfo] r ON s.ServerID=r.ServerID
	LEFT JOIN [QPPlatformDB].[dbo].[GameGameItem] g ON s.KindID=g.GameID
	WHERE 1=1
'	+@Where + '
	SELECT totalCount=Count(1) FROM '+ @tempTable + '

	SELECT * FROM ' + @tempTable + '
	WHERE RowNo BETWEEN '+CONVERT(VARCHAR(10),(@pageIndex-1)*@pageSize+1)+' AND '+CONVERT(VARCHAR(10),@pageIndex*@pageSize)+'
	ORDER BY RowNO 

	DROP TABLE '+@tempTable

	--SELECT @SQL
	EXEC(@SQL)
END

GO




