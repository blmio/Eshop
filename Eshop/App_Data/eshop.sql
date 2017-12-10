/*============================*/
-- 分页的存储过程
/*============================*/
--------------------------------

create procedure [sp_pageview]
@selectlist varchar(2000),		--字段列表
@tablename varchar(100),		--表名
@fldName varchar(100),			-- 分页条件字段名
@wherestr varchar(2000)=null,		--查询条件
@pageindex int=1,			--页号
@pagesize int=15,			--每页显示条数
@orderstr varchar(2000)='order by [Number] desc',--排序字段
@pagecount int output,			---总页数
@allcount int output			---总记录数
AS
begin

if @selectlist is null begin set @selectlist='*' end			----字段列如果不定义为*
print @selectlist							----打印、输出字段信息
if @pageindex is null or @pageindex<1 begin set @pageindex=1 end	----当前页数据如果小于1或为空都等于1
print @pageindex
if @pagesize is null or @pagesize<1 begin set @pagesize=15 end		----每页显示条数
print @pagesize
declare @sql nvarchar(2000)
set @sql='select @allcount=count(*) from '+@tablename+' where 1=1 '+@wherestr
EXEC sp_executesql  @sql,N'@allcount int OUTPUT',@allcount output 
print @allcount
if (@allcount%@pagesize)=0 begin set @pagecount=@allcount/@pagesize end
else begin set @pagecount=(@allcount/@pagesize)+1 end
if @pageindex>@pagecount begin set @pageindex=@pagecount end
declare @pag int 
if @pagesize>1 begin set @pag=str((@pageindex-1)*@pagesize+1) end
else begin set @pag=0 end

declare @sqlstr varchar(4000)
if @allcount>@pagesize 
	begin 
	set @sqlstr='select top '+str(@pagesize)+' '+@selectlist+' from '+@tablename+' where '+@fldName+'  not in(select top '+str((@pageindex-1)*@pagesize)+' '+@fldName+' from '+@tablename+' where 1=1 '+@wherestr+@orderstr+')'+@wherestr+@orderstr
end
else
	begin
	set @sqlstr='select top '+str(@pagesize)+' '+@selectlist+' from '+@tablename+' where 1=1 '+@wherestr+@orderstr
end

print @sqlstr

SET NOCOUNT ON
    EXECUTE(@sqlstr)
    SET NOCOUNT OFF
    RETURN @@RowCount
END

/*======================综合设置======================*/

/* 后台管理员表 */
create table [e_admin]
(
[Number]      varchar(50) primary key,		---编码
[emid]        varchar(60),                  ---
[upid]        varchar(60),                  ---分类编号
[Rank]        int null default (0),         ---等级
[CloseS]      int null default (0),         ---是否关闭
[Aname]       varchar(20),                  ---用户名
[Apasswoid]   varchar(60),                  ---密码
[RealityName] varchar(20),                  ---真实名字
[Lasttime]    varchar(200),                 ---最后一次登录时间
[Lotimes]     int null default (0),         ---登录次数
[Atime]       datetime not null default (getdate()),
)

/* 用户表 */
create table [e_member]
(
[Number]      varchar(50) primary key,		---编码
[Name]        varchar(50),                  ---登录名
[Password]    varchar(50),                  ---密码
[NickName]    varchar(50),                  ---昵称
[Sex]         int null default (0),         ---性别{0|保密，1|男，2|女}
[Birth]       varchar(50),                  ---出生年月
[Mobile]      varchar(20),                  ---手机号码
[RealName]    varchar(50),                  ---真实姓名
[UserPic]     varchar(200),                 ---头像路径
[Email]       varchar(200),                 ---邮箱地址
[Address]     varchar(200),                 ---居住地址
[Content]     text,							---会员介绍
[LogIp]       varchar(50),                  ---登录IP
[Lotimes]     int null default (0),         ---登录次数
[CloseS]      int null default (0),			---是否关闭
[Atime]       datetime not null default (getdate()),
)

/* 广告图片 */
create table [e_ads_flash]
(
[Number]      varchar(50) primary key,		---编码
[upid]        varchar(60),                  ---
[url]         varchar(200),                 ---链接路径
[ImgS]        varchar(200),                 ---图片
[title]       varchar(200),                 ---名称
[Description] varchar(255),                 ---图片描述
[CloseS] int null default (0),				---是否关闭
[Stat] int null default (0),				---排序
[Reded] int null default (0),				---是否推荐
[Atime] datetime not null default (getdate()),
)

/* Flash切换图片 */
create table [e_flash]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(20),					---
[url]    varchar(200),					---链接
[ImgS]   varchar(200),					---链接图片
[title]  varchar(200),					---标题名
[Description] varchar(255),             ---图片描述
[CloseS] int null default (0),			---是否关闭
[Reded]  int null default (0),			---是否推荐
[Stat]   int null default (0),			---排序
[Atime]   datetime not null default (getdate()),
)

/* 商品分类 */
create table [e_goods_cate]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(50),					---分类编号
[title]  varchar(200),					---名称
[sitetitle]   varchar(255),			          ---页面标题
[Keywords]    varchar(255),			          ---页面关键字
[Description] varchar(255),			          ---页面描述
[CloseS] int null default (0),			---是否关闭
[Reded]  int null default (0),			---是否推荐
[top]    int null default (0),		    ---推荐显示
[Stat]   int null default (0),			---排序
[Grade]  int null default (0),	        ---等级数
[Atime]   datetime not null default (getdate()),
)

/* 搜索关键词表 */
create table [e_keydata]
(
[Number] varchar(50) primary key,		---编码
[upid] varchar(50) null default ('0'),	---搜索编号
[keywords] varchar(250),				---关键字
[num] int null default (0),				---搜索次数
[keydate] varchar(200),					---最后一次搜索时间
[UserHostAddress] varchar(200),			---客户端的 IP
[UserHostName] varchar(200),			---客户端的 DNS 名
[CloseS] int null default (0),			---是否关闭
[Stat] int null default (0),			---排序
[Reded] int null default (0),			---是否推荐
[hot] int null default (0),			    ---是否热门
[Atime] datetime not null default (getdate()),
)

/* 导航分类 */
create table [e_navigation]
(
[Number]      varchar(50) primary key,		  ---编码
[upid]        varchar(200),				      ---分类编号
[title]       varchar(200),				      ---名称
[sitetitle]   varchar(255),			          ---页面标题
[Keywords]    varchar(255),			          ---页面关键字
[Description] varchar(255),			          ---页面描述
[url]         varchar(200),				      ---链接
[Stat]        int null default (0),		      ---排序
[CloseS]      int null default (0),		      ---是否关闭
[Reded]       int null default (0),			  ---是否推荐
[Atime]       datetime not null default (getdate()),
)

/* 帮助信息 */
create table [e_helplist]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(50),					---分类编号
[title]  varchar(200),					---名称
[url]    varchar(200),				    ---链接
[CloseS] int null default (0),			---是否关闭
[Reded]  int null default (0),			---是否推荐
[Stat]   int null default (0),			---排序
[Grade]  int null default (0),	        --- 等级数
[Atime]  datetime not null default (getdate()),
)

/* 所有物品表 */
create table [e_goods]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(50),                   ---一级分类编号
[upids]  varchar(50),                   ---二级分类编号
[emid]   varchar(50),                   ---商品编号
[title]  varchar(200),					---标题
[subtitle]  varchar(200),				---子标题
[price]  money,                         ---价格   
[ImgS]   varchar(255),					---缩略图
[BuyT]   int null default (0),			---购买次数
[ScanT]  int null default (0),			---浏览次数
[sitetitle]   varchar(255),			    ---页面标题
[Keywords]    varchar(255),			    ---页面关键字
[Description] varchar(255),			    ---页面描述
[Content]  text,			            ---详情信息
[PackList] text,                        ---包装清单
[CloseS] int null default (0),			---是否关闭
[Stat]   int null default (0),			---排序
[Reded]  int null default (0),			---是否推荐
[hot] int null default (0),			    ---是否热门
[Atime] datetime not null default (getdate()),
)

/* 物品介绍图片 */
create table [e_goods_pic]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(50),                   ---分类编号
[title]  varchar(250),                  ---标题
[ImgS]   text,                          ---图片路径
[CloseS] int null default (0),			---是否关闭
[Stat]   int null default (0),			---排序
[Reded]  int null default (0),			---是否推荐
[Atime] datetime not null default (getdate()),
)

/* 购物车 */
create table [e_cart]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(50),                   ---用户编号
[emid]   varchar(50),                   ---商品编号
[title]  varchar(200),					---商品标题
[price]  money,                         ---价格
[ImgS]   varchar(255),					---缩略图
[count]  int null default (0),			---数量
[Atime] datetime not null default (getdate()),
)


/* 我的订单 */
create table [e_order]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(50),                   ---用户编号
[emid]   varchar(50),                   ---商品编号
[title]  varchar(200),					---商品标题
[price]  money,                         ---订单金额
[ImgS]   varchar(255),					---缩略图
[Stus]   int null default (0),			---订单状态{0|确认收货，1|评价晒单，2|完成交易}
[count]  int null default (0),			---数量
[CloseS] int null default (0),			---是否关闭
[Stat]   int null default (0),			---排序
[Reded]  int null default (0),			---是否推荐
[Atime] datetime not null default (getdate()),
)

/* 收货地址 */
create table [e_address]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(50),                   ---用户编号
[receN]  varchar(50),                   ---收货人
[receA]  varchar(200),                  ---收货地址
[receAD] varchar(250),                  ---详细地址
[Code]   varchar(20),                   ---邮编
[Mobile] varchar(20),                   ---手机号码
[Phone]  varchar(20),                   ---固定电话
[Atime] datetime not null default (getdate()),
)

/* 商品评价 */
create table [e_appra]
(
[Number] varchar(50) primary key,		---编码
[upid]   varchar(50),                   ---用户编号
[emid]   varchar(50),                   ---商品编号
[Name]   varchar(50),                   ---用户名
[title]  varchar(200),					---商品标题
[Level]  int not null default(0),       ---评价等级{0|好评，1|中评，2|差评}
[Content]   text,			            ---详情信息
[buyTime]   datetime,                   ---购买时间
[CloseS] int null default (0),			---是否关闭
[Stat]   int null default (0),			---排序
[Reded]  int null default (0),			---是否推荐
[Atime] datetime not null default (getdate()),
)