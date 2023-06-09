﻿
CREATE VIEW [dbo].[GolferRounds]
AS
SELECT  G.GolferId, G.Name, G.FullName, G.Avatar, G.Enabled, G.Alias, G.BringsBeer, GR.GolferRoundId, GR.Score, GR.Points, GR.Par3sWon, GR.WonGame, GR.Comments, 
		(SELECT SUM(GR2.Points) FROM dbo.GolferRound GR2 INNER JOIN dbo.Round AS R2 ON GR2.RoundId = R2.RoundId WHERE GR2.GolferId = G.GolferId AND R2.Date <= R.Date AND YEAR(R2.Date) = YEAR(R.Date)) AS PointsYTD,
		R.RoundId, R.Date, R.Name AS RoundName, R.Details, R.Game, R.BeerDutyGolferId, R.IsMajor, 
		BD.Name AS BeerDutyName, BD.FullName AS BeerDutyFullName, BD.Avatar AS BeerDutyAvatar, BD.Enabled AS BeerDutyEnabled, 
		C.CourseId, C.Name AS CourseName, C.Url, C.Zip, C.Latitude, C.Longitude, C.Par, C.Rating, C.Slope
FROM    dbo.Golfer AS G INNER JOIN
        dbo.GolferRound AS GR ON G.GolferId = GR.GolferId INNER JOIN
        dbo.Round AS R ON GR.RoundId = R.RoundId INNER JOIN
        dbo.Course AS C ON R.CourseId = C.CourseId LEFT OUTER JOIN
        dbo.Golfer AS BD ON R.BeerDutyGolferId = BD.GolferId


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "G"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 210
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GR"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 216
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "R"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 633
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 6
               Left = 671
               Bottom = 136
               Right = 841
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BD"
            Begin Extent = 
               Top = 6
               Left = 879
               Bottom = 136
               Right = 1049
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 33
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'GolferRounds';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'GolferRounds';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'GolferRounds';

