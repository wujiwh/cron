C# Cron4Win
---------------------------
supports most cron scheduling.  See tests for supported formats.

```
*    *    *    *    *  
┬    ┬    ┬    ┬    ┬
│    │    │    │    │
│    │    │    │    │
│    │    │    │    └───── day of week (0 - 6) (Sunday=0 )
│    │    │    └────────── month (1 - 12)
│    │    └─────────────── day of month (1 - 31)
│    └──────────────────── hour (0 - 23)
└───────────────────────── min (0 - 59)
```

```
  `* * * * *`        Every minute.
  `0 * * * *`        Top of every hour.
  `0,1,2 * * * *`    Every hour at minutes 0, 1, and 2.
  `*/2 * * * *`      Every two minutes.
  `1-55 * * * *`     Every minute through the 55th minute.
  `* 1,10,20 * * *`  Every 1st, 10th, and 20th hours.
  
`* * * * *  d:\1.exe` //每分钟执行d:\1.exe程序
`01 * * * * d:\1.exe` //每小时执行d:\1.exe程序
`02 4 * * * d:\1.exe` //每天执行d:\1.exe程序
`22 4 * * 0 d:\1.exe` //每星期执行d:\1.exe程序
`42 4 1 * * d:\1.exe` //每月去执行d:\1.exe程序

```

Console Example
===============
