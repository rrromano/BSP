USE WIADBISYS
GO

/****************************************************************************************************/
If Exists ( Select 1 From sysobjects Where Name = 'ad_who' )
  Drop Table ad_who
Go
Create Table dbo.ad_who (
      spid      varchar(   40 ) Null ,
      status    varchar(   40 ) Null ,
      loginame  varchar(   40 ) Null ,
      hostname  varchar(   40 ) Null ,
      blk       varchar(   40 ) Null ,
      dbname    varchar(   40 ) Null ,
      cmd       varchar(   40 ) Null )

/****************************************************************************************************/
/* Vuelca en la tabla ad_who el resultado de sp_who */
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_who')
  Drop Procedure adp_who
Go 
CREATE PROCEDURE adp_who as
set nocount on
  delete from ad_who
  insert into ad_who
 exec sp_who
print 'OK'
set nocount off
Go


/*****************************************************************************************************/
Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_helptextfb')
  Drop Procedure sp_helptextfb
Go 
create procedure [dbo].[sp_helptextfb] --- cualquier duda consultar sp_helptext ( the original!! )
@n_1552_objname nvarchar(776),
@s_200_bp varchar(200) = '', --pk
@i_10_cl int = 1            --pk
as
/*************************************************************************************************************/
/*                                                                                                           */
/* ojo: si el stored tiene comentarios previos , los va a perder!!!!!!!                                      */
/*                                                                                                           */
/*************************************************************************************************************/
set nocount on
declare @dbname sysname
,@blankspaceadded     int
,@basepos             int
,@currentpos          int
,@textlength          int 
,@addonlen            int
,@lfcr                int --lengths of line feed carriage return
,@definedlength       int
,@syscomtext          nvarchar(4000)
,@line                nvarchar(255)
,@flag                int
,@blinea              varchar(300)--pk
,@imprimio            bit         --pk
,@nlinea              int         --pk
,@ultlinea            int         --pk
if @i_10_cl < -1
  set @i_10_cl = -1
if @s_200_bp = ''            --pk
  select @imprimio = 1 --pk
else                   --pk
  select @imprimio = 0 --pk
select @nlinea = 0
if isnumeric(@s_200_bp) = 1
  select @ultlinea = convert(int,@s_200_bp)
else if @i_10_cl < 0
  select @ultlinea = 0
else
  select @ultlinea = - @i_10_cl
select @definedlength = 255
select @blankspaceadded = 0 
select @lfcr = 2
select @flag = 0
declare syscomcursor  cursor local forward_only read_only for
  select text
    from syscomments
   where id = object_id(@n_1552_objname)
     and encrypted = 0
order by number, colid
open syscomcursor
fetch next from syscomcursor into @syscomtext
while @@fetch_status >= 0
begin
  select  @basepos  = 1
  select  @currentpos = 1
  select  @textlength     = len(@syscomtext)
            while @currentpos  != 0
              begin
                --looking for end of line followed by carriage return
                select @currentpos =   charindex(char(13)+char(10), @syscomtext, @basepos)
                  
                --if carriage return found
                if @currentpos != 0
                  begin
                    while (isnull(len(@line),0) + @blankspaceadded + @currentpos-@basepos + @lfcr) > @definedlength
                      begin
                        select @addonlen = @definedlength-(isnull(len(@line),0) + @blankspaceadded)
                        if @flag != 0
                          begin
                            set @blinea = isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @addonlen), N'')--pk
                            if @s_200_bp <> '' --pk esto es para que no pierda tiempo al pedo
                              begin                                                   --pk
                                set @nlinea = @nlinea + 1
                                if isnumeric(@s_200_bp) = 0 and charindex(@s_200_bp,@blinea) <> 0 --pk
                                  begin
                                    print convert(char(6),@nlinea) + '=> ' + @blinea
                                    set @ultlinea = @nlinea
                                    set @imprimio = 1
                                  end
                                else
                                  begin
                                    if @i_10_cl < 0 or (@ultlinea > 0 and @ultlinea + @i_10_cl > @nlinea and @ultlinea <= @nlinea)
                                      print convert(char(6),@nlinea) + ' - ' + @blinea
                                  end 
                              end --pk
                            else
                              begin
                     print @blinea 
                              end
                          end
                        else
                          begin
                            set @blinea = substring( isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @addonlen), N'') , charindex ( 'create' , isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @addonlen), N'') ) , @definedlength )



                            if @s_200_bp <> '' --pk esto es para que no pierda tiempo al pedo
                              begin                                                   --pk
                                set @nlinea = @nlinea + 1
                                if isnumeric(@s_200_bp) = 0 and charindex(@s_200_bp,@blinea) <> 0 --pk
                                  begin
                                    print convert(char(6),@nlinea) + '=> ' + @blinea
                                    set @ultlinea = @nlinea
                                    set @imprimio = 1
                                  end
                                else
                                  begin
                                    if @i_10_cl < 0 or (@ultlinea > 0 and @ultlinea + @i_10_cl > @nlinea and @ultlinea <= @nlinea)
                                      print convert(char(6),@nlinea) + ' - ' + @blinea
                                  end 
                              end                                                     --pk
                            else
                              begin
                                print @blinea
                              end
                            set @flag = 1
                          end
                        select @line = null
                             , @basepos = @basepos + @addonlen
                             , @blankspaceadded = 0
                      end
                    if @flag != 0
                      select @line    = isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @currentpos-@basepos + @lfcr), N'')
                    else
                      begin
                        select @line = isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @currentpos-@basepos + @lfcr), N'')
                        select @line = substring( @line , charindex( 'create' , @line ) , @definedlength )
                        set @flag = 1
                      end
                    select @basepos = @currentpos+2
                    set @blinea = @line
                    if @s_200_bp <> '' --pk esto es para que no pierda tiempo al pedo
                      begin                                                   --pk
                        set @nlinea = @nlinea + 1
                        if isnumeric(@s_200_bp) = 0 and charindex(@s_200_bp,@blinea) <> 0 --pk
                          begin
                            print convert(char(6),@nlinea) + '=> ' + @blinea
                            set @ultlinea = @nlinea
                            set @imprimio = 1
                          end
                        else
                          begin
                            if @i_10_cl < 0 or (@ultlinea > 0 and @ultlinea + @i_10_cl > @nlinea and @ultlinea <= @nlinea)
                              print convert(char(6),@nlinea) + ' - ' + @blinea
                          end 
                      end                                                     --pk
                    else
                      begin
                        print @blinea
                      end
                    select @line    = null
                  end
                else --else carriage return not found
                  begin
                    if @basepos < @textlength
                      begin
                        while (isnull(len(@line),0) + @blankspaceadded + @textlength-@basepos+1 ) > @definedlength
                          begin
 select @addonlen = @definedlength - (isnull(len(@line),0)  + @blankspaceadded )
                            if @flag != 0
                             begin
                                set @blinea = isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @addonlen), N'')
                                if @s_200_bp <> '' --pk esto es para que no pierda tiempo al pedo
                                  begin                                                   --pk
                                    set @nlinea = @nlinea + 1
                                    if isnumeric(@s_200_bp) = 0 and charindex(@s_200_bp,@blinea) <> 0 --pk
                                      begin
                                        print convert(char(6),@nlinea) + '=> ' + @blinea
                                        set @ultlinea = @nlinea
                                        set @imprimio = 1
                                      end
                                    else
                                      begin
                                        if @i_10_cl < 0 or (@ultlinea > 0 and @ultlinea + @i_10_cl > @nlinea and @ultlinea <= @nlinea)
                                          print convert(char(6),@nlinea) + ' - ' + @blinea
                                      end 
                                  end                                                     --pk
                                else
                                  begin
                                    print @blinea
                                  end
                              end
                            else
                              begin
                                set @blinea = substring( isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @addonlen), N'') , charindex( 'create' , isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @addonlen), N'') ) , @definedlength




)                        
                                if @s_200_bp <> '' --pk esto es para que no pierda tiempo al pedo
                                  begin                                                   --pk
                                    set @nlinea = @nlinea + 1
                                    if isnumeric(@s_200_bp) = 0 and charindex(@s_200_bp,@blinea) <> 0 --pk
                                      begin
                                        print convert(char(6),@nlinea) + '=> ' + @blinea
                                        set @ultlinea = @nlinea
                                        set @imprimio = 1
                                      end
                                    else
                                      begin
                                        if @i_10_cl < 0 or (@ultlinea > 0 and @ultlinea + @i_10_cl > @nlinea and @ultlinea <= @nlinea)
                                          print convert(char(6),@nlinea) + ' - ' + @blinea
                                      end 
                                  end                                                     --pk
                                else
                                  begin
                                    print @blinea
                                  end
                                set @flag = 1
                              end
                              select @line = null
                                 , @basepos = @basepos + @addonlen
                                 , @blankspaceadded = 0
                          end
                          select @line = isnull(@line, N'') + isnull(substring(@syscomtext, @basepos, @textlength-@basepos+1 ), N'')
                          if charindex(' ', @syscomtext, @textlength+1 ) > 0
                            begin
                              select @line = @line + ' '
                                   , @blankspaceadded = 1
                            end
                          break
 end
                  end
  end
  fetch next from syscomcursor into @syscomtext
end 
if @line is not null
  begin
    set @blinea = @line
    if @s_200_bp <> '' --pk esto es para que no pierda tiempo al pedo
      begin                                                   --pk
        set @nlinea = @nlinea + 1
        if isnumeric(@s_200_bp) = 0 and charindex(@s_200_bp,@blinea) <> 0 --pk
          begin
            print convert(char(6),@nlinea) + '=> ' + @blinea
            set @ultlinea = @nlinea
            set @imprimio = 1
          end
        else
          begin
            if @i_10_cl < 0 or (@ultlinea > 0 and @ultlinea + @i_10_cl > @nlinea and @ultlinea <= @nlinea)
            print convert(char(6),@nlinea) + ' - ' + @blinea
          end 
      end                                                     --pk
    else
      begin
    print @blinea
      end
  end
if @s_200_bp = '' print 'g' + 'o'
if @imprimio = 0 and isnumeric(@s_200_bp) = 0
  print '(no se encontraron lineas que contengan la palabra buscada)'
if @s_200_bp <> ''
  begin
    print '_____________________________________'
    print 'cantidad total de lineas: ' + convert(varchar(6),@nlinea)
    print ''
  end
close  syscomcursor
deallocate  syscomcursor
return (0) -- sp_helptext
go


If Exists ( Select 1 From SysObjects Where Name = 'sp_helptexto')
  Drop Procedure sp_helptexto
Go 
CREATE PROCEDURE sp_helptexto 
  @sp varchar(200) = '',
  @bp varchar(200) = '0',
  @cl int = 0 --PK: N lineas despues de la que contiene la palabra @bp
As
declare @sString as varchar(1000)
declare @nLen    as integer
declare @nID     as smallint
declare @sDB     as varchar(1000)
Set NoCount On
if @cl < -1 
  set @cl = -1
If @sp = ''
  Begin
    Print 'Se Requiere el Parametro @sp'
    Return 1
  End
If @sp = 'MATES' Begin Print '           ª          ' Print '            \         '
                       Print '             \        ' Print '              \       '
                       Print '             __\__    ' Print '            /     \   '
                       Print '           /       \  ' Print '          /000000000\ '
                       Print '         |           |' Print '         |===========|'
                       Print '          \_________/ ' Print '                      '
                       Print ' ¨Nos tomamos unos ricos mates?' Return 0 End
Select @nID = @@SPID
Select @sDB = db_name(dbid)
  From Master..SysProcesses
 Where spid = @nID
If Exists ( Select 1 
              From SysObjects
             Where name = @sp
               And xtype In ( 'P' , 'V' , 'TR' , 'RF' ) ) and (@bp In ('0' , '1') or @cl <> 0)--PK
  Begin
    if @cl = 0                                                                                --PK
      begin                                                                                   --PK
        Select @sString = 'Set NoCount On 
                    Print ''Use ' + IsNull( @sDB , 'AdintaR' ) + '
G' + 'o ''
                    Print ''If Exists ( Select 1 From SysObjects Where Name = ''''' + @sp + ''''')
  Drop ' + case xtype
             when 'P'  Then 'Procedure'
             When 'V'  Then 'View'
             When 'TR' Then 'Trigger'
             When 'RF' Then 'Procedure'
           end + ' ' + @sp + '
G' + 'o ''
           Exec sp_helptextfb ' + @sp
          From SysObjects
         Where name = @sp
           And xtype In ( 'P' , 'V' , 'TR' , 'RF' )
      End                                                                                     --PK
    else                                                                                      --PK
      begin                                                                                   --PK
        Select @sString = 'Print ''Buscando lineas en ''''' + @sp + ''''' con la palabra ''''' + @bp + ''''' 
------------------------------------------------------------------------------------------------------''
Exec sp_helptextfb ''' + @sp + ''', ''' + @bp + ''', ' + convert(varchar(10),@cl)
      end --PK
    Exec (@sString)
  End
Else
  Begin
    If @bp = '0'
      Begin
        Select @nLen = Len(@sp)
        Select @nLen = Case @nLen
                         When 1 Then 1
                 When 2 Then 1
                         When 3 Then 1
                         When 4 Then 1
                         Else Round( ( @nLen / 4 ) , 0 , 1 ) + 1
                       End
    /*                                                                                                           */
        Select @sString = Case
                When @nLen = 1           Then Left(@sp , @nLen)
                            When @nLen > 1 And Left(@sp, 3) = 'sp_'  Then Left(@sp , 3 + @nLen)
                            When @nLen > 1 And Left(@sp, 3) = 'xp_'  Then Left(@sp , 3 + @nLen)
                            When @nLen > 1 And Left(@sp, 4) = 'adp_' Then Left(@sp , 4 + @nLen)
                            Else Left(@sp, @nLen)
                          End + '%'
        Print @sString
        select 'Exec sp_helptexto ' + name as SPS
          From SysObjects
         Where name like @sString
           And xtype In ( 'P' , 'V' , 'TR' , 'RF' )
         Order By 1
    /*                                                                                                           */
        Select @sString = '%' + Case @nLen
                                  When 1 Then @sp
                                  Else SubString( @sp , (@nLen + 1) , (Len(@sp) - (2 * @nLen) ) )
                                End + '%'
        Print @sString
        select 'Exec sp_helptexto ' + name as SPS
          From SysObjects
         Where name like @sString
           And xtype In ( 'P' , 'V' , 'TR' , 'RF' )
         Order By 1
    /*                                                                                                           */
        Select @sString = '%' + Right(@sp, @nLen)
        Print @sString
        select 'Exec sp_helptexto ' + name as SPS
          From SysObjects
         Where name like @sString
           And xtype In ( 'P' , 'V' , 'TR' , 'RF' )
         Order By 1
    /*                                                                                                           */
        Select @sString = Left( @sp , @nLen ) + '%' + Right( @sp , @nLen )
        Print @sString
        select 'Exec sp_helptexto ' + name as SPS
          From SysObjects
         Where name like @sString
           And xtype In ( 'P' , 'V' , 'TR' , 'RF' )
         Order By 1
      End
    Else /* Busca Palabra                                                                                        */
      Begin
        If @bp = '1'
          Begin
            Print 'Buscando SPs con la Palabra ''%' + @sp + '%'' . . . '
            Select Distinct 'Exec sp_helptexto ''' + Name + '''' as SPS
              From SysObjects
             Inner Join SysComments 
                On SysObjects.id = SysComments.id
             Where SysComments.Text Like '%' + @sp + '%'
             Order By SPS
          End
        Else /* Busca ESA Palabra                                                                                */
          Begin
            Print '¨Tiene ' + @sp + ' la palabra ' + @bp + ' ?'
            If Exists ( Select 1
                          From SysComments
                         Where Text Like '%' + @bp + '%'
                           And Object_Name(id) = @sp   )
              Print 'SI.  Felicidades.'
            Else
              Print 'NO.  Segui participando.'
          End
      End
  End
Return 0
Go

/******************************************************************************************************/

If Exists ( Select 1 From SysObjects Where Name = 'sp_val_busca_tabla')
  Drop Procedure sp_val_busca_tabla
Go 
CREATE PROCEDURE sp_val_busca_tabla
                    @S_200_tabla varchar(200)  = '%',
                    @N_1_simil numeric(1)    = 1
as
-- Busca Tablas en el Sistema
print 'Tablas con nombre ' + case @N_1_simil
                               when 1 then 'similar '
                               else 'igual '
                             end + 'a "' + @S_200_tabla + '" en la Base: '
print replicate('_', 83)
if @N_1_simil = 1 set @S_200_tabla = '%' + @S_200_tabla + '%'
select substring(name, 1, 83) as Nombre from sysobjects where name like @S_200_tabla and xtype = 'U'
if @@error <> 0
  return 0
return 1
Go

/******************************************************************************************************/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_busca_campo')
  Drop Procedure sp_val_busca_campo
Go 
 
CREATE PROCEDURE sp_val_busca_campo 
                    @S_200_campo varchar(200)  = '%',
                    @N_1_simil numeric(1)    = 1,
                    @N_1_orden numeric(1)    = 1
as
-- Busca Campos en Las Tablas del Sistema
print 'Campos con nombre ' + case @N_1_simil
                               when 1 then 'similar '
                               else 'igual '
                             end + 'a "' + @S_200_campo + '" en las Tablas de la Base: '
print replicate('_', 83)
if @N_1_simil = 1 set @S_200_campo = '%' + @S_200_campo + '%'
if @N_1_orden = 1 begin
  select substring(object_name(id), 1, 30) as Tabla,
         substring(name,1,30)              as Campo,
         substring(type_name(xtype), 1, 3) as Tipo,
         case type_name(xtype)
           when 'varchar' then str(length, 4)
           when 'numeric' then str(xprec, 4)
           else '    '
         end                               as Largo,
         case convert(numeric(1),xscale)
           when 0 then ' '
           else ltrim(str(xscale))
         end                               as Decimales 
    from syscolumns where name like @S_200_campo 
     and id in (select id 
                  from sysobjects 
                 where xtype = 'U')
   order by 1, 2, 3, 4, 5
end
if @N_1_orden = 2 begin
  select substring(object_name(id), 1, 30) as Tabla,
         substring(name,1,30)              as Campo,
         substring(type_name(xtype), 1, 3) as Tipo,
         case type_name(xtype)
           when 'varchar' then str(length, 4)
           when 'numeric' then str(xprec, 4)
           else '    '
         end                               as Largo,
         case convert(numeric(1),xscale)
           when 0 then ' '
           else ltrim(str(xscale))
         end                               as Decimales 
    from syscolumns where name like @S_200_campo 
     and id in (select id 
                  from sysobjects 
                 where xtype = 'U') 
   order by 2, 1, 3, 4, 5
end
if @N_1_orden = 3 begin
  select substring(object_name(id), 1, 30) as Tabla,
         substring(name,1,30)              as Campo,
         substring(type_name(xtype), 1, 3) as Tipo,
         case type_name(xtype)
           when 'varchar' then str(length, 4)
           when 'numeric' then str(xprec, 4)
           else '    '
         end                               as Largo,
         case convert(numeric(1),xscale)
           when 0 then ' '
           else ltrim(str(xscale))
         end                               as Decimales 
    from syscolumns where name like @S_200_campo 
     and id in (select id 
                  from sysobjects 
                 where xtype = 'U') 
   order by 3, 1, 2, 4, 5
end
if @N_1_orden = 4 begin
  select substring(object_name(id), 1, 30) as Tabla,
         substring(name,1,30)              as Campo,
         substring(type_name(xtype), 1, 3) as Tipo,
         case type_name(xtype)
           when 'varchar' then str(length, 4)
           when 'numeric' then str(xprec, 4)
           else '    '
         end                               as Largo,
         case convert(numeric(1),xscale)
           when 0 then ' '
           else ltrim(str(xscale))
         end                               as Decimales 
    from syscolumns where name like @S_200_campo 
     and id in (select id 
                  from sysobjects 
                 where xtype = 'U') 
   order by 4, 1, 2, 3, 5
end
if @N_1_orden = 5 begin
  select substring(object_name(id), 1, 30) as Tabla,
         substring(name,1,30)              as Campo,
         substring(type_name(xtype), 1, 3) as Tipo,
         case type_name(xtype)
           when 'varchar' then str(length, 4)
           when 'numeric' then str(xprec, 4)
           else '    '
         end                               as Largo,
         case convert(numeric(1),xscale)
           when 0 then ' '
           else ltrim(str(xscale))
         end                               as Decimales 
    from syscolumns where name like @S_200_campo 
     and id in (select id 
                  from sysobjects 
                 where xtype = 'U') 
   order by 5, 1, 2, 3, 4
end
if @@error <> 0
  return 0
return 1
Go

/******************************************************************************************************/
/*
Busca
Busca objetos en el sistema
PARAMETROS: Elem   S(60)
	  Simil  N(1)  [DEFAULT = 1]
	  Si simil = 1 ; El sp buscará tabla , campo o Sp con nombre similar a Elem
	  Si simil = 0 ; El sp buscará tabla , campo o Sp con nombre igual a Elem
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'Busca')
  Drop Procedure Busca
Go 
CREATE PROCEDURE Busca
                    @S_200_elem varchar(200)  = '%',
                    @N_1_simil numeric(1)    = 1
as
-- Busca Tablas en el Sistema
-- BUSCA (eltima Actualizacion 22/11/2000 (FB))
set nocount on
exec sp_val_busca_tabla @S_200_elem, @N_1_simil
print replicate('~', 83)
exec sp_val_busca_campo @S_200_elem, @N_1_simil
print replicate('~', 83)
exec sp_helptexto @S_200_elem , 1
print replicate('~', 83)
set nocount off
if @@error <> 0
  return 1
return 0
Go

/******************************************************************************************************/
/*
busca_parametros [DEPRECATED]
      Recupera la lista de parámetros de un SP.
      PARAMETRO: Nombre_SP S(50)
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'busca_parametros')
  Drop Procedure busca_parametros
Go 
CREATE PROCEDURE busca_parametros @S_50_Nombre_SP varchar(50)
as
declare @nObject_Id  integer
declare @nStart      integer
declare @nEnd        integer
declare @tParameters varchar(4000)
if not exists(select id from sysobjects where name = @S_50_Nombre_SP)
begin 
  print 'El Stored Procedure ' + upper(@S_50_Nombre_SP) + ' no existe.'
  return -102
end
select @nObject_Id = id from sysobjects where name = @S_50_Nombre_SP
select top 1 @nStart = patindex('%@%', text)from syscomments where id = @nObject_Id
select top 1 @nEnd = patindex('%as%', text)from syscomments where id = @nObject_Id
if @nStart > @nEnd 
begin
  print 'El Stored Procedure ' + upper(@S_50_Nombre_SP) + ' no tiene parametros.'
  return -101
end
set @tParameters = ltrim (substring((select top 1 text from syscomments where id = @nObject_Id),@nStart,@nEnd - @nStart))
print @tParameters
return 0
Go


/*****************************************************************************************************/
/*
Buscavalor
      Busca los registros de una tabla q' en alguno de sus campos contengan cierto valor o similar.
      PARAMETROS: Tabla S(60)
                  Valor S(60) --> Para Fecha Usar AAAA-MM-DD HH:MM:SS
                  Simil N(1) = 0
                  Simil funciona del mismo modo q' en Busca
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'Buscavalor')
  Drop Procedure Buscavalor
Go 
CREATE PROCEDURE Buscavalor (
                    @S_60_tabla            as varchar (60),
                    @S_60_valor            as varchar (60), --Para Fecha Usar AAAA-MM-DD HH:MM:SS
                    @I_10_Coincidir_campo  as integer =0
                             )
as
declare @campo as varchar (40)
declare @Condicion_campo  as varchar (20)
declare @String as varchar(1000)
--set nocount on
declare cu_tab cursor local forward_only read_only for
  select c.name from syscolumns c, sysobjects o
   where c.id = o.id and o.name = @S_60_tabla
     and c.name not in ('login_conf', 'login_modif', 'fecha_modif' , 'fecha_conf' , 'term_modif', 'term_conf')
if @I_10_Coincidir_campo = 1 set @Condicion_campo = ' = '
if @I_10_Coincidir_campo = 0
  begin
    set @Condicion_campo = ' like '
    set @S_60_valor= '%' + @S_60_valor + '%'
  end
print @S_60_tabla
open cu_tab
while 1=1
  begin
    fetch cu_tab into 
    @campo
    if @@fetch_status <> 0 break
--    Print '  ' + @campo
--    print '-------------------------------------------------------------------------------------------'
    if @S_60_valor is null
      begin
        Set @String = 'If Exists ( Select 1 from ' + @S_60_tabla + ' where convert(varchar(60),' + @campo + ', 20) is null) ' +
              ' select ''' + @campo + ''' as NombreCampo, * from ' + @S_60_tabla + ' where convert(varchar(60),' + @campo + ', 20 ) is null'
      end
    else
      begin
        Set @String = 'If Exists ( Select 1 from ' + @S_60_tabla + ' where convert(varchar(60),' + @campo + ', 20)' + @Condicion_campo + '''' + @S_60_valor + ''') ' +
              ' select ''' + @campo + ''' as NombreCampo, * from ' + @S_60_tabla + ' where convert(varchar(60),' + @campo + ', 20 )' + @Condicion_campo + '''' + @S_60_valor + ''''
      end
--    Print @String
    Exec (@String)
  end
return 0
Go

/******************************************************************************************************/
/*
BV2
Busca todos los registros de la base en los q' cierto campo sea = o parecido a cierto valor
Si Valor Is Null ; Busca los distintos valores existentes en la base para el campo
PARAMETROS: Campo S(100)
	  Valor S(20)   [DEFAULT = Null]
	  Ident N(1)    [DEFAULT = 1]
	  Ident funciona a la inversa de simil.
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'BV2')
  Drop Procedure BV2
Go 
CREATE PROCEDURE BV2
  @S_100_Campo Varchar(100) ,
  @S_20_Valor Varchar(20) = Null,
  @I_10_Ident Integer = 0
As
--Busca todos los registros de la base en los q' @S_100_Campo sea = o parecido ( segun @I_10_Ident ) a @S_20_Valor
--Si Valor Is Null ; Busca los distintos valores existentes en la base para el campo @S_100_Campo
Declare @Tabla VarChar(60)
Declare @Tipo  VarChar(60)
Declare Cu Cursor Local Fast_Forward For
  Select Object_Name( Id ) , Type_Name( XType ) From SysColumns Where Name = @S_100_Campo
Open Cu
While 1=1
  Begin
    Fetch Cu Into @Tabla , @Tipo
    If @@Fetch_Status != 0 Break
    Print ''
    Print UPPER(@Tabla) + ' :'
    Select @S_20_Valor = Convert( Varchar(20) , @S_20_Valor , 120 )
    If @S_20_Valor Is Not Null
      If @S_20_Valor = 'Null'
        Exec ( 'Select * From ' + @Tabla + ' Where ' + @S_100_Campo + ' Is Null ' )
      Else
        If @I_10_Ident = 0
          Exec ( 'Select * From ' + @Tabla + ' Where Convert( Varchar(20) , ' + @S_100_Campo + ' , 120 ) Like ''%' + @S_20_Valor + '%''' )
        Else
          Exec ( 'Select * From ' + @Tabla + ' Where Convert( Varchar(20) , ' + @S_100_Campo + ' , 120 ) = ''' + @S_20_Valor + '''' )
    Else
      Exec ( 'Select Distinct ' + @S_100_Campo + ' From ' + @Tabla )
  End
Close Cu
Deallocate Cu
Go

/******************************************************************************************************/
/*
PKT
      Este store arma una consulta a la tabla especificada en @S_3000_Tabla, si no encuentra la tabla
      imprime tres listas de tablas con nombre similares al que figura en @S_3000_Tabla, si la tabla 
      existe pero algun campo del where es incorrecto despliega la descripcion de la tabla, si 
      la tabla no existe y hay un error de sintaxis muestra la consulta SQL para poder determinar
      cual fue el problema, y por ultimo si la tabla existe pero hay un error de sintaxis ademas 
      de mostrar la consulta SQL muestra la descripcion de dicha tabla
      Si en @S_1000_Option se pasa un string que no sea numerico y no tenga espacios, parentesis ni signos
      de igualdad ('=') y en @S_1000_Where se le pasa un string, arma el where con un like de la siguiente 
      forma: <@S_1000_Option> Like '%<@S_1000_Where>%'
      PARAMETROS: Tabla    S(3000)
                  Option   S(1000) [DEFAULT Null]
                    Puede ser un numero para traer los primeros @Option registros 
                    o bien un filtro para armar el where 
                    o bien un campo para armar el like 
                    o un ordenamiento
                  Where    S(1000) [DEFAULT Null]
                    Solo puede ser un filtro 
                    o un valor para armar el like 
                    o un ordenamiento                                                                               
                  WhereSec S(1000) [DEFAULT Null]
                    Solo puede ser un filtro 
                    o un ordenamiento 
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'PKT')
  Drop Procedure PKT
Go 
CREATE PROCEDURE PKT
    @S_3000_Tabla    varchar(3000)       , 
    @S_1000_Option   varchar(1000) = null, -- Puede ser un numero para traer los primeros @S_1000_Option registros o bien un filtro para armar el where o bien un campo para armar el like o un ordenamiento
    @S_1000_Where    varchar(1000) = null, -- Solo puede ser un filtro o un valor para armar el like o un ordenamiento                                                                               
    @S_1000_WhereSec varchar(1000) = null  -- Solo puede ser un filtro o un ordenamiento                                                                                                             
as 
-------------------------------------------------------------------------------------------------
-- Este store arma una consulta a la tabla especificada en @S_3000_Tabla, si no encuentra la tabla
-- imprime tres listas de tablas con nombre similares al que figura en @S_3000_Tabla, si la tabla 
-- existe pero algun campo del where es incorrecto despliega la descripcion de la tabla, si 
-- la tabla no existe y hay un error de sintaxis muestra la consulta SQL para poder determinar
-- cual fue el problema, y por ultimo si la tabla existe pero hay un error de sintaxis ademas 
-- de mostrar la consulta SQL muestra la descripcion de dicha tabla
-- Si en @S_1000_Option se pasa un string que no sea numerico y no tenga espacios, parentesis ni signos
-- de igualdad ('=') y en @S_1000_Where se le pasa un string, arma el where con un like de la siguiente 
-- forma: <@S_1000_Option> Like '%<@S_1000_Where>%'
-------------------------------------------------------------------------------------------------
-- CREATED BY HORUS Corp
-------------------------------------------------------------------------------------------------
declare @AuxT     varchar(3000)
declare @AuxC     varchar(1000)
declare @AuxW     varchar(3000)
declare @AuxS     varchar(3000)
declare @AuxO     varchar(1000)
declare @AuxFind  varchar(4000)
declare @AuxChars varchar(50)
declare @Err      int
declare @AuxN     int
declare @Like     bit
declare @ShowSQL  bit
declare @ShowDesc bit
declare @ShowRes  bit
declare @Par      bit
declare @i        int
set @S_3000_Tabla = upper(@S_3000_Tabla)
set @AuxChars = ''
set @AuxS = '*'
set @ShowDesc = 0
set @ShowSQL = 0
set @ShowRes = 1
set @Par = 0
set @i = len(@S_3000_Tabla)
while @i > 0
  begin
    set @i = @i - 1
    if left(@S_3000_Tabla,1) = '-'
      begin
        if @ShowSQL = 0
          begin
            set @AuxChars = @AuxChars + left(@S_3000_Tabla,1)
            set @ShowSQL = 1  
            set @Par = 1
          end
        set @S_3000_Tabla = Substring(@S_3000_Tabla,2,len(@S_3000_Tabla)-1)
        continue
      end
    if left(@S_3000_Tabla,1) = '!'
      begin
        if @ShowRes = 1
          begin
            set @AuxChars = @AuxChars + left(@S_3000_Tabla,1)
            set @ShowRes = 0
            set @Par = 1
          end
        set @S_3000_Tabla = Substring(@S_3000_Tabla,2,len(@S_3000_Tabla)-1)
        continue
      end
    if left(@S_3000_Tabla,1) = '*'
    begin
        if @AuxS = '*'
          begin
            set @AuxChars = @AuxChars + left(@S_3000_Tabla,1)
            set @AuxS = 'COUNT(*) AS Cantidad'
          end
        set @S_3000_Tabla = Substring(@S_3000_Tabla,2,len(@S_3000_Tabla)-1)
        continue
      end
    if left(@S_3000_Tabla,1) = '$'
      begin
        if @ShowDesc = 0
          begin
            set @AuxChars = @AuxChars + left(@S_3000_Tabla,1)
            set @ShowDesc = 1
            set @Par = 1
          end
        set @S_3000_Tabla = Substring(@S_3000_Tabla,2,len(@S_3000_Tabla)-1)
        continue
      end
    
    break
  end
set @S_3000_Tabla = replace(@S_3000_Tabla,char(13),'')
set @S_3000_Tabla = replace(@S_3000_Tabla,char(10),'')
set @AuxFind = 'select ''exec pkt ''''' + @AuxChars + ''' + convert(varchar(40),name) + ''''''''' +
                 ' + isnull('','''''' + ' + isnull('convert(varchar(3000),''' + replace(convert(varchar(3000),@S_1000_Option),'''','''''''''') + ''') + ''''''''','NULL') + ','''')' +
                 ' + isnull('','''''' + ' + isnull('convert(varchar(3000),''' + replace(convert(varchar(3000),@S_1000_Where),'''','''''''''') + ''') + ''''''''','NULL') + ','''')' +
                 ' + isnull('','''''' + ' + isnull('convert(varchar(3000),''' + replace(convert(varchar(3000),@S_1000_WhereSec),'''','''''''''') + ''') + ''''''''','NULL') + ','''')' +
                 ' from sysobjects where xtype = ''U'' and name like '
if charindex('%',@S_3000_Tabla) = 0
  begin
    Set @Like = 0
    
    if @S_1000_Option is null or len(@S_1000_Option) = 0
      begin        
        set @AuxC = ''
        set @AuxW = ''
        set @AuxO = ''
      end
    else
        if right(rtrim(@S_1000_Option),1) = '<' or right(rtrim(@S_1000_Option),1) = '>'
          begin
            set @AuxC = ''
            set @AuxW = ''
            set @AuxO = ' ORDER BY ' + replace(replace(@S_1000_Option,'<',' ASC '),'>',' DESC ')
          end
        else if isnumeric(@S_1000_Option) = 1
          begin
            set @AuxC = ' TOP ' + convert(varchar(9),@S_1000_Option) 
            set @AuxW = ''
            set @AuxO = ''
          end
        else
          begin
            set @AuxC = '' 
            If (charindex(' ',@S_1000_Option) = 0) and (charindex('(',@S_1000_Option) = 0) and (charindex('=',@S_1000_Option) = 0) and (@S_1000_Where is not null)
              Set @Like = 1
            set @AuxW = ' WHERE ' + @S_1000_Option
            set @AuxO = ''
          end
    
    if @S_1000_Where is not null and len(@S_1000_Where) > 0
      begin  
        if right(rtrim(@S_1000_Where),1) = '<' or right(rtrim(@S_1000_Where),1) = '>'
          begin
            if @AuxO = ''
              set @AuxO = ' ORDER BY '
            else
              set @AuxO = @AuxO + ', '
            set @AuxO = @AuxO + replace(replace(@S_1000_Where,'<',' ASC '),'>',' DESC ')
          end
        else if @AuxW = ''
          begin
            set @AuxW = ' WHERE ' + @S_1000_Where
          end
        else
          if @Like = 1
            begin
              if left(@S_1000_Where,1) <> '%'
                begin
                  set @S_1000_Where = replace(@S_1000_Where,'[','[[]')
                  set @S_1000_Where = replace(@S_1000_Where,'_','[_]')
                  set @S_1000_Where = replace(@S_1000_Where,'%','[%]')
                end
              set @AuxW = @AuxW + ' LIKE ''%' + @S_1000_Where + '%'''
            end
          else
            begin
              set @AuxW = @AuxW + ' AND ' + @S_1000_Where
            end
      end
    if @S_1000_WhereSec is not null and len(@S_1000_WhereSec) > 0
      begin  
        if right(rtrim(@S_1000_WhereSec),1) = '<' or right(rtrim(@S_1000_WhereSec),1) = '>'
          begin
            if @AuxO = ''
              set @AuxO = ' ORDER BY '
            else
              set @AuxO = @AuxO + ', '
            set @AuxO = @AuxO + replace(replace(@S_1000_WhereSec,'<',' ASC '),'>',' DESC ')
          end
        else
          begin
            if @AuxW = ''
              begin
                set @AuxW = ' WHERE ' + @S_1000_WhereSec
              end
            else
              begin
                set @AuxW = @AuxW + ' AND ' + @S_1000_WhereSec
              end
          end
      end
    if @ShowSQL = 1
      begin
        print ''
        print '--------------------------------------------------------------------------------------------'
        print 'SQL :'
        print ''
        print ' SELECT' + @AuxC + ' ' + @AuxS
        print ' FROM ' + @S_3000_Tabla 
        if @AuxW <> ''
          print @AuxW  
        if @AuxO <> ''
          print @AuxO
        print ''
      end
    
    set @Err = 0
    if @ShowDesc = 1
      begin
        if exists(select 1 from sysobjects where name = @S_3000_Tabla and xType = 'U')
          begin
            print ''
            print '--------------------------------------------------------------------------------------------'
            exec ('exec descr ''' + @S_3000_Tabla + '''')
          end
        else
          begin
            Set @Err = 208
            print 'TABLA INEXISTENTE'
            print '--------------------------------------------------------------------------------------------'
          end
      end
    if @ShowRes = 1 and @Err = 0
      begin
        if @Par = 1
          begin
            print ''
            print '============================================================================================'
            print '==      RESULTADO                                                                         =='
            print '============================================================================================'
            print ''
          end
        exec ('SELECT' + @AuxC + ' ' + @AuxS + ' FROM ' + @S_3000_Tabla + @AuxW + @AuxO)
        set @Err=@@Error
      end
    if @Err <> 0
        begin
           if @Err <> 208
              begin
                if exists(select 1 from sysobjects where name = @S_3000_Tabla and xType = 'U') 
                  begin
                    if @ShowDesc = 0
                      begin
                        print ''
                        print '--------------------------------------------------------------------------------------------'
                        exec ('exec descr ''' + @S_3000_Tabla + '''')
                      end
                  end
                else
                  begin
                    print ''
                    print '--------------------------------------------------------------------------------------------'
                print 'La tabla ''' + @S_3000_Tabla + ''' es inexistente'
                  end
              end
            else
                begin
                  set @AuxN = round(len(@S_3000_Tabla)/4,0)
                  if @AuxN < 4 or @AuxN is null
                    set @AuxN = 3
                  set @AuxT = left(@S_3000_Tabla,@AuxN)
                  print ''
                  print '--------------------------------------------------------------------------------------------'
                  print ' BUSCANDO TABLAS QUE CONTENGAN ''' + upper(@AuxT) + '%'''
                  print '--------------------------------------------------------------------------------------------'
                  exec (@AuxFind + '''' + @AuxT + '%'' order by name')
                  set @AuxN = round(len(@S_3000_Tabla)/4,0)
                  if @AuxN < 4 or @AuxN is null
                    set @AuxN = 3
                  set @AuxT = right(@S_3000_Tabla,@AuxN)
                  print ''
                  print '--------------------------------------------------------------------------------------------'
                  print ' BUSCANDO TABLAS QUE CONTENGAN ''%' + upper(@AuxT) + ''''
         print '--------------------------------------------------------------------------------------------'
                  exec (@AuxFind + '''%' + @AuxT + ''' order by name')
                  set @AuxN = round(len(@S_3000_Tabla)/4,0)
                  if @AuxN < 1 or @AuxN is null
                    set @AuxN = 1
                  set @AuxT = substring(@S_3000_Tabla,@AuxN,len(@S_3000_Tabla)-(@AuxN*2))
                  print ''
                  print '--------------------------------------------------------------------------------------------'
                  print ' BUSCANDO TABLAS QUE CONTENGAN ''%' + upper(@AuxT) + '%'''
                  print '--------------------------------------------------------------------------------------------'
                  exec (@AuxFind + '''%' + @AuxT + '%'' order by name')
                end
        end
  end
else
  begin
    if ascii(substring(@S_3000_Tabla,1,1))=37 and ascii(substring(@S_3000_Tabla,2,1))=67 and ascii(substring(@S_3000_Tabla,3,1))=79 and ascii(substring(@S_3000_Tabla,4,1))=70 and ascii(substring(@S_3000_Tabla,5,1))=70 and ascii(substring(@S_3000_Tabla,6,1
))=69 and 
    ascii(substring(@S_3000_Tabla,7,1))=69 begin print replicate(char(13),1)+replicate(' ',7)+replicate(' ) ',4)+replicate(' ',3)+replicate(char(13),1)+replicate(' ',7)+replicate('(  ',4)+replicate(' ',3)+replicate(char(13),1)+replicate(' ',6)+replicate('
  )',
    2)+replicate('_',2)+replicate(')  ',2)+replicate(' ',2)+replicate(char(13),1)+replicate(' ',6)+replicate('_',1)+replicate('.',1)+replicate('-',1)+replicate('´',1)+replicate(' ',6)+replicate('´',1)+replicate('-',1)+replicate('.',1)+replicate('_',1)+
    replicate(' ',2)+replicate(char(13),1)+replicate(' ',5)+replicate('|',1)+replicate('-',1)+replicate('.',1)+replicate('_',1)+replicate(' ',8)+replicate('_',1)+replicate('.',1)+replicate('-',1)+replicate('|',1)+replicate(' ',1)+replicate(char(13),1)+
    replicate(' ',5)+replicate('|',1)+replicate(' ',4)+replicate('´',1)+replicate(' ',1)+replicate('-',2)+replicate(' ',1)+replicate('´',1)+replicate(' ',4)+replicate('|',1)+replicate(' ',1)+replicate('_',3)+replicate(' ',1)+replicate(char(13),1)+
    replicate(' ',5)+replicate('|',1)+replicate(' ',14)+replicate('|',1)+replicate(' ',1)+replicate(' ',3)+replicate('|',1)+replicate(char(13),1)+replicate(' ',5)+replicate('|',1)+replicate(' ',14)+replicate('|',1)+replicate(' ',1)+replicate(' ',3)+
    replicate('|',1)+replicate(char(13),1)+replicate(' ',5)+replicate('|',1)+replicate(' ',14)+replicate('|',1)+replicate(' ',1)+replicate(' ',3)+replicate('|',1)+replicate(char(13),1)+replicate(' ',5) + replicate('|',1)+replicate(' ',14)+replicate('|',
    1)+replicate(' ',1)+replicate('_',3)+replicate('|',1)+replicate(char(13),1)+replicate(' ',5)+replicate('|',1)+replicate(' ',14)+replicate('|',1)+replicate(' ',1)+replicate(char(13),1)+replicate(' ',5)+replicate('\',1)+replicate(' ',14)+replicate('/'
    ,1)+replicate(' ',1)+replicate(char(13),1)+replicate(' ',4)+replicate('_',2)+replicate('\',1)+replicate('_',12)+replicate('/',1)+replicate('_',2)+replicate(char(13),1)+replicate(' ',4)+replicate('\',1)+replicate('_',16)+replicate('/',1) end else
      begin
        set @AuxT = @S_3000_Tabla
        print ''
        print '--------------------------------------------------------------------------------------------'
        print ' BUSCANDO TABLAS QUE CONTENGAN ''' + upper(@AuxT) + ''''
        print '--------------------------------------------------------------------------------------------'
        if @ShowSQL = 1
          exec (@AuxFind + '''' + @AuxT + ''' order by name')
        else
          exec ('select name as TABLA from sysobjects where xtype = ''U'' and name like ''' + @AuxT + '''')
      end
  end
Go

/*****************************************************************************************************/
/*
descr
Describe una Tabla , Vista o SP.
PARAMETROS: Tabla S(100)
	  Gyf   Bit(1)  [DEFAULT = 0]
	  Si Gyf = 1, Busca la descripción en Gyf_Tablas.
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'descr')
  Drop Procedure descr
Go 
CREATE PROCEDURE descr
    @S_100_tabla varchar(100)
  , @B_1_gyf   Bit = 0
as
declare @S_100_tabla_id numeric (15)
declare @desc varchar(200)
set @S_100_tabla_id = (select id
                 from sysobjects s
                 where s.name = @S_100_tabla)
if @S_100_tabla_id is not null 
begin
  If Exists ( Select 1 From SysObjects Where Name = 'Gyf_Tablas' )
 And Exists ( Select 1 From SysObjects Where Name = 'Gyf_Campos' )
 And @B_1_gyf != 0
  Begin
-- CON DESCRIPCION --------------------------------------------------------------------------------------------
    set nocount on
    Select @desc = 'Descripcion de Tabla ' + upper(@S_100_tabla) + '(' + descripcion + ') :'
      From Gyf_Tablas
     Where base = db_name()
       And tabla = @S_100_tabla
    print @desc
    print '' 
  
    select Convert( VarChar(40) , Rtrim( c.name ) ) as Campos ,
           gyf.descripcion as Descripcion ,
           convert (varchar(15),t.name) + case when c.status >= 0x80 then ' identity' else '' end as Tipo_de_Datos ,
           Longitud =
           case 
              when t.name in ( 'numeric' , 'decimal' ) then
                Str( c.xprec , 5 )
              when t.name like '%int%'      then ' '
              when t.name like '%bit%'      then ' '
              when t.name like '%datetime%' then ' '
              else
                Str( c.length , 5 )
              end,
           Decimales =    
           case 
              when c.xscale > 0 and t.name <> 'datetime' then
                convert(varchar(1),c.xscale)
              else
                ' '
              end,
           case c.isnullable 
              when 1 then
                 'SI'
              else
                 ' '
              end
           as 'Null',
           PK = 
               case
                  when c.colid = k.colid then
                    'X'
                  else
                    ' '
                  end,
           Foreign_Key = Left(
                         Case
                           When ( Select count(*)
                                    From SysForeignKeys
                                   Where fkeyid = c.id
                                     And fkey   = c.colid ) = 0 Then ''
                           When ( Select count(*)
                                    From SysForeignKeys
                                   Where fkeyid = c.id
                                     And fkey   = c.colid ) = 1 Then ( Select Object_Name(rkeyid)
                                                                            + '.' + Col_name(rkeyid,rkey)
                                                                         From SysForeignKeys
                                                                        Where fkeyid = c.id
                                                                          And fkey   = c.colid )
                           Else '(Varias)'
                         End
                        , 40 )
       , Referenced_By = Left(
                         Case
                           When ( Select count(*)
                                    From SysForeignKeys
                                   Where rkeyid = c.id
                                     And rkey   = c.colid ) = 0 Then ''
                           When ( Select count(*)
                                    From SysForeignKeys
                                   Where rkeyid = c.id
                                     And rkey   = c.colid ) = 1 Then ( Select Object_Name(fkeyid)
                                                                            + '.' + Col_name(fkeyid,fkey)
                                                                         From SysForeignKeys
                                                                        Where rkeyid = c.id
                                                                          And rkey   = c.colid )
                           Else 'Referido por ' + Str( ( Select count(*)
                                                           From SysForeignKeys
                                                          Where rkeyid = c.id
                                                            And rkey   = c.colid ) , 5 ) + ' Tablas '
                         End
                        , 40 )
    from syscolumns c
    inner join systypes t on
    c.xtype = t.xtype
  
    left outer join sysindexkeys k on
      (    c.id = k.id
       and c.colid = k.colid
       and k.indid = 1)
    left outer join gyf_campos gyf on
      (    gyf.base  = db_name()
       and gyf.tabla = @S_100_tabla
       and gyf.campo = c.name )
  
    where c.id = @S_100_tabla_id
    order by PK desc , c.colid
  
    set nocount off
    return 0
-- CON DESCRIPCION --------------------------------------------------------------------------------------------
  End
  Else
  Begin
-- SIN DESCRIPCION --------------------------------------------------------------------------------------------
    set nocount on
  
    print 'Descripcion de Tabla ' + upper(@S_100_tabla) + ':'
    print '' 
  
    select Convert( VarChar(40) , Rtrim( c.name ) ) as Campos ,
           convert (varchar(15),t.name) + case when c.status >= 0x80 then ' identity' else '' end as Tipo_de_Datos ,
           Longitud =
           case 
              when t.name in ( 'numeric' , 'decimal' ) then
                Str( c.xprec , 5 )
              when t.name like '%int%'      then ' '
              when t.name like '%bit%'      then ' '
              when t.name like '%datetime%' then ' '
              else
                Str( c.length , 5 )
              end,
           Decimales =    
           case 
              when c.xscale > 0 and t.name <> 'datetime' then
                convert(varchar(1),c.xscale)
              else
                ' '
              end,
           case c.isnullable 
              when 1 then
                 'SI'
              else
                 ' '
              end
           as 'Null',
           PK = 
               case
                  when c.colid = k.colid then
                    'X'
                  else
                    ' '
                  end,
           Foreign_Key = Left(
                         Case
                           When ( Select count(*)
                                    From SysForeignKeys
                                   Where fkeyid = c.id
                                     And fkey   = c.colid ) = 0 Then ''
                           When ( Select count(*)
                                    From SysForeignKeys
                                   Where fkeyid = c.id
                                     And fkey   = c.colid ) = 1 Then ( Select Object_Name(rkeyid)
                                                                            + '.' + Col_name(rkeyid,rkey)
                                                                         From SysForeignKeys
                                                                        Where fkeyid = c.id
                                                                          And fkey   = c.colid )
                           Else '(Varias)'
                         End
                        , 40 )
       , Referenced_By = Left(
                         Case
                           When ( Select count(*)
                                    From SysForeignKeys
                                   Where rkeyid = c.id
                                     And rkey   = c.colid ) = 0 Then ''
                           When ( Select count(*)
                                    From SysForeignKeys
                                   Where rkeyid = c.id
                                     And rkey   = c.colid ) = 1 Then ( Select Object_Name(fkeyid)
                                  + '.' + Col_name(fkeyid,fkey)
                                                                      From SysForeignKeys
                                                                        Where rkeyid = c.id
                                                                          And rkey   = c.colid )
                           Else 'Referido por ' + Str( ( Select count(*)
                                                           From SysForeignKeys
                                                          Where rkeyid = c.id
                                                            And rkey   = c.colid ) , 5 ) + ' Tablas '
                         End
                        , 40 )
    from syscolumns c
    inner join systypes t on
    c.xtype = t.xtype
  
    left outer join sysindexkeys k on
      (    c.id = k.id
       and c.colid = k.colid
       and k.indid = 1)
  
    where c.id = @S_100_tabla_id
    order by PK desc , c.colid
  
    set nocount off
    return 0
-- SIN DESCRIPCION --------------------------------------------------------------------------------------------
  End
end
else
begin
    print 'Tabla ' + upper(@S_100_tabla) + ' Inexistente.' 
    exec PKT @S_100_tabla
    return -1
end
Go

/*****************************************************************************************************/
/*
descr1
      Idem Descr, pero sin Gyf y no muestra FK ni References
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'descr1')
  Drop Procedure descr1
Go 
CREATE PROCEDURE descr1
                @S_200_tabla varchar(200)
as
declare @Aux as numeric(5)
set @Aux = 0
select @Aux = max(len(b.name))
from sysobjects a,syscolumns b
 where a.id=b.id  and a.name=@S_200_tabla
 
print @S_200_tabla + ':'
select b.name + replicate(' ',@Aux - len(b.name)) + ' ' + type_name(b.xtype)
        + case b.xtype
            when 61 then ' '
            else '(' + case convert(varchar(2),xprec)
                         when 0 then convert(varchar(3),length)
                           else case xscale
                                when 0 then convert(varchar(2),xprec)
                                else convert(varchar(2),xprec) + ',' + convert(varchar(2),xscale)
                             end
                       end
                 + ')' 
          end
        + case isnullable
                  when 0 then ' not null' else ' null' end
from sysobjects a,syscolumns b 
 where a.id=b.id  and a.name=@S_200_tabla
 order by a.id
Go

/*****************************************************************************************************/
/*
fecsis
Muestra o Cambia la fecha del sistema.
PARAMETROS: Fecha Date
	    Si Fecha Is Null, muestra la fecha del sistema.
	    Si no, cambia la fecha del sistema por @Fecha.
*/
Go 

If Exists ( Select 1 From SysObjects Where Name = 'fecsis')
  Drop Procedure fecsis
Go 
CREATE PROCEDURE fecsis
  @D_16_Fecha DateTime = Null
AS
Declare @sql_fecha As Varchar(254)
Set NoCount On
Print 'Fecha Actual:'
Select @sql_fecha = sql_fecha from gyf_empresa
Exec ( @sql_fecha )
If @@Error != 0
  select fecsis from gyf_empresa
If @D_16_Fecha is Not Null
  Begin
    UpDate Gyf_Empresa
       Set fecsis = @D_16_Fecha
    
    If @@Error !=0
      Print 'No se ha podido Actualizar la Fecha!'
    Else
      Begin
        Print 'Se cambio la Fecha a:'
        Exec ( @sql_fecha )
        If @@Error != 0
          select fecsis from gyf_empresa
      End
  End
Go

/******************************************************************************************************/
/*
find
Busca objetos en la tabla sysobjects
PARAMETROS: Nom  S(40)
	  Tipo S(1)   [DEFAULT = %]
	  Tipo de objeto segun sysobjects
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'find')
  Drop Procedure find
Go 
CREATE PROCEDURE find 
(@S_40_nom varchar (40),
 @S_1_tipo varchar(1) = '%')  as
set @S_40_nom = replace(@S_40_nom,'_','[_]')
select substring(name,1,30) as Encontrado,xtype as Tipo
  from sysobjects
 where name like '%' + @S_40_nom + '%' 
   and xtype like @S_1_tipo
 order by 1 desc
Go

/*****************************************************************************************************/
/*
pkh
ALIAS PARA SP_HELPTEXTO
*/
Go 
If Exists ( Select 1 From SysObjects Where Name = 'pkh')
  Drop Procedure pkh
Go 
CREATE PROCEDURE pkh
  @S_200_sp varchar(200) = '',
  @S_200_bp varchar(200) = '0',
  @I_10_cl int = 0 --PK: N lineas despues de la que contiene la palabra @S_200_bp
as
 exec sp_helptexto @S_200_sp,@S_200_bp,@I_10_cl
Go

/******************************************************************************************************/
/*
PKV
*/
Go 
If Exists ( Select 1 From SysObjects Where Name = 'pkv')
  Drop Procedure pkv
Go 
CREATE PROCEDURE pkv
  @N_512_Valor      nvarchar(256),
  @N_512_Tabla      nvarchar(256) = null
as
declare @N_512_TablaAux nvarchar(256)
declare @Like     nvarchar(10)
/*
if @N_512_Tabla is null
  declare cur cursor local fast_forward read_only for
    select name from sysobjects with (readuncommitted) where xtype = 'U'
else
  declare cur cursor local fast_forward read_only for
    select name from sysobjects with (readuncommitted) where xtype = 'U' and name = @N_512_Tabla
*/
create table #PKV_Tablas (
  id_id int primary key,
  campo nvarchar(256),
--  cadena nvarchar(3700)
  cadena ntext
)
create table #PKV_Campos (
  id_id int primary key,
  campo nvarchar(256)
)
insert into #PKV_Tablas (id_id, campo, cadena)
  select 
    id, 
    name,
    'select count(*) from ' + name + ' where '
  from 
    sysobjects with (readuncommitted)
  where 
    xtype = 'U' and 
    (name = @N_512_Tabla or @N_512_Tabla is null)
if charindex('%',@N_512_Valor) > 0
  set @Like = 'LIKE'
else
  set @Like = '='
  update a 
    set 
      cadena = cadena + b.name + ' ' + @Like + ' ''' + @N_512_Valor + ''' and '
    from 
      #PKV_Tablas a 
      join syscolumns b
        on a.id_id = b.id
exec pkt '#PKV_Tablas'
/*
insert into #PKV_Campos (id_id, campo)
  select 
    id, 
    name 
  from 
    syscolumns with (readuncommitted)
    join #PKV_Tablas on syscolumns.id = #PKV_Tablas.id_id
  where
*/
/*
open cur
while 1=1
  begin
    fetch cur into @N_512_TablaAux
    if @@fetch_status <> 0
      begin
        break
      end
    
  end
close cur
deallocate cur
*/
Go

/******************************************************************************************************/
/*
sp_dpnds
Muestra las dependencias de un objeto basado en SysDepends
PARAMETROS: Objeto S(200)
	  Grado  I(10)   [DEFAULT = 1]
	    Indica la cantidad de grados de dependencia q' se abrirán
	  Direc  I(10)   [DEFAULT = 0]
	    Indica la dirección de la busqueda:
	      1 - Los q' dependen de él
	      2 - De los q' él depende
	      0 - Ambos
	  Debug  I(10)   [DEFAULT = 0]
	    Indica impresión de comentarios en la ejecución.
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_dpnds')
  Drop Procedure sp_dpnds
Go 
CREATE PROCEDURE sp_dpnds
                    @S_200_Objeto VarChar(200) ,
                    @I_10_Grado  Int = 1      ,
                    @I_10_Direc  Int = 0      , --1 = Los q' dependen de el
                                           --2 = D q' depende
                                           --0 = Todos
                    @I_10_Debug  Int = 0      
As
Declare @Gr     Int
Declare @String VarChar(2000)
set nocount on
If Not Exists ( Select 1
                  From SysObjects
                 Where Name = @S_200_Objeto ) Begin
  Exec pkt @S_200_Objeto
  Return 1
End
Print 'Referencias:'
Print '---> = UpDate ; - -> = Select'
Print '~~~> = Read   ; ªªª> = Otro  '
Print '                             '
Create Table #Aux ( Objeto Varchar(100) )
Insert Into #Aux ( Objeto ) Values ( @S_200_Objeto )
Set @Gr = 1
While @I_10_Grado >= @Gr
  Begin
    Select @String = 'Alter Table #Aux Add Rel' + Convert( VarChar(3) , @Gr ) + 'F Char(4)'
    Exec (@String)
    Select @String = 'Alter Table #Aux Add Rel' + Convert( VarChar(3) , @Gr ) + 'B Char(4)'
    Exec (@String)
    Select @String = 'Alter Table #Aux Add Obj' + Convert( VarChar(3) , @Gr ) + 'F VarChar(35)'
    Exec (@String)
    Select @String = 'Alter Table #Aux Add Obj' + Convert( VarChar(3) , @Gr ) + 'B VarChar(35)'
    Exec (@String)
    Set @Gr = @Gr + 1
  End
-- ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> --
If @I_10_Direc In ( 0 , 1 )
  Begin
    Print ' Objetos que dependen de ' + @S_200_Objeto
    Set @Gr = 1
    While @I_10_Grado >= @Gr
      Begin
        Select @String = 'Insert Into #Aux ( Obj' + Convert( Varchar(3) , @Gr ) + 'B'
                                         + ',Rel' + Convert( Varchar(3) , @Gr ) + 'B'
                                         + ',Objeto ) '
                       + 'Select Distinct Object_Name(Id) , Case
                                                              When ResultObj = 1 Then ''--->''
                                                              When SelAll    = 1 Then ''- ->''
                                                              When ReadObj   = 1 Then ''~~~>''
                                                              Else ''ªªª>''
                                                            End , ' + Case
                                                                        When 1 = @Gr Then ' Objeto '
                                                                        Else ' Obj' + Convert( Varchar(3) , @Gr - 1 ) + 'B'
                                                                      End
                       + ' From SysDepends , #Aux
                          Where Object_Name( depid ) = ' + Case
                                                             When 1 = @Gr Then ' Objeto '
                                                             Else ' Obj' + Convert( Varchar(3) , @Gr - 1 ) + 'B'
                                                           End
        If @I_10_Debug > 2
          Print @String
        Exec ( @String )                                     
        Set @Gr = @Gr + 1
      End
    Set @Gr = 1
    Set @String = 'Select Distinct Convert( Varchar(' + Str(Len(@S_200_Objeto)) + ') , A1.Objeto ) '
    While @I_10_Grado >= @Gr
      Begin
        Select @String = @String + ' , IsNull( A' + Convert( VarChar(3) , @Gr ) + '.Rel' + Convert( VarChar(3) , @Gr ) + 'B , '''' )'
                                 + ' , IsNull( A' + Convert( VarChar(3) , @Gr ) + '.Obj' + Convert( VarChar(3) , @Gr ) + 'B , '''' )'
        Set @Gr = @Gr + 1
      End
    Set @String = @String + '  From #Aux A1'
    Set @Gr = 2
    While @I_10_Grado >= @Gr
      Begin
        Select @String = @String + '  Left Outer Join #Aux A' + Convert( VarChar(3) , @Gr )
                                 + '    On ( A' + Convert( VarChar(3) , @Gr ) + '.Objeto'
          + '       = A' + Convert( VarChar(3) , @Gr - 1 ) + '.Obj' + Convert( VarChar(3) , @Gr - 1 ) + 'B'
                                 + ')'
        Set @Gr = @Gr + 1
      End
    Select @String = @String + ' Where A1.Objeto = ''' + @S_200_Objeto + ''' Order By Convert( Varchar(' + Str(Len(@S_200_Objeto)) + ') , A1.Objeto ) '
    Set @Gr = 1
    While @I_10_Grado >= @Gr
      Begin
        Select @String = @String + ', IsNull( A' + Convert( VarChar(3) , @Gr ) + '.Obj' + Convert( VarChar(3) , @Gr ) + 'B , '''') '
        Set @Gr = @Gr + 1
      End
    If @I_10_Debug > 0
      Print @String
    If @I_10_Debug > 1
      Select * From #Aux
    Exec ( @String )
  End
-- ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> ---> --
-- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- --
If @I_10_Direc In ( 0 , 2 )
  Begin
    Print ' Objetos de los que depende ' + @S_200_Objeto
    Set @Gr = 1
    While @I_10_Grado >= @Gr
      Begin
        Select @String = 'Insert Into #Aux ( Obj' + Convert( Varchar(3) , @Gr ) + 'F'
                                         + ',Rel' + Convert( Varchar(3) , @Gr ) + 'F'
                                         + ',Objeto ) '
                       + 'Select Distinct Object_Name(DepId) , Case
                                                                 When ResultObj = 1 Then ''<---''
                                                                 When SelAll    = 1 Then ''<- -''
                                                                 When ReadObj   = 1 Then ''<~~~''
                                                                 Else ''<ªªª''
                                                               End , ' + Case
                                                                        When 1 = @Gr Then ' Objeto '
                                                                        Else ' Obj' + Convert( Varchar(3) , @Gr - 1 ) + 'F'
                                                                      End
                       + ' From SysDepends , #Aux
                          Where Object_Name( id ) = ' + Case
                                                          When 1 = @Gr Then ' Objeto '
                                                          Else ' Obj' + Convert( Varchar(3) , @Gr - 1 ) + 'F'
                                                        End
        If @I_10_Debug > 2
          Print @String
        Exec ( @String )                                     
        Set @Gr = @Gr + 1
      End
    Set @Gr = 1
    Set @String = 'Select Distinct Convert( Varchar(' + Str(Len(@S_200_Objeto)) + ') , A1.Objeto ) '
    While @I_10_Grado >= @Gr
      Begin
        Select @String = @String + ' , IsNull( A' + Convert( VarChar(3) , @Gr ) + '.Rel' + Convert( VarChar(3) , @Gr ) + 'F , '''' )'
                                 + ' , IsNull( A' + Convert( VarChar(3) , @Gr ) + '.Obj' + Convert( VarChar(3) , @Gr ) + 'F , '''' )'
        Set @Gr = @Gr + 1
      End
    Set @String = @String + '  From #Aux A1'
    Set @Gr = 2
    While @I_10_Grado >= @Gr
      Begin
        Select @String = @String + '  Left Outer Join #Aux A' + Convert( VarChar(3) , @Gr )
                                 + '    On ( A' + Convert( VarChar(3) , @Gr ) + '.Objeto'
                                 + '       = A' + Convert( VarChar(3) , @Gr - 1 ) + '.Obj' + Convert( VarChar(3) , @Gr - 1 ) + 'F'
                                 + ')'
        Set @Gr = @Gr + 1
      End
    Select @String = @String + ' Where A1.Objeto = ''' + @S_200_Objeto + ''' Order By Convert( Varchar(' + Str(Len(@S_200_Objeto)) + ') , A1.Objeto ) '
    Set @Gr = 1
    While @I_10_Grado >= @Gr
      Begin
        Select @String = @String + ', IsNull( A' + Convert( VarChar(3) , @Gr ) + '.Obj' + Convert( VarChar(3) , @Gr ) + 'F , '''') '
        Set @Gr = @Gr + 1
      End
    If @I_10_Debug > 0
      Print @String
    If @I_10_Debug > 1
      Select * From #Aux
    Exec ( @String )
  End
-- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- <--- --
-- ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? --
If @I_10_Direc Not In ( 0 , 1 , 2 )
  Begin
    Print ' Te Equivocaste. Las posibles direcciones son:
                                           1 = Los que dependen de ' + @S_200_Objeto + '
                                           2 = De los que depende ' + @S_200_Objeto + '
                                           0 = Todos
          '
    End
-- ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? ???? --
Drop Table #Aux
Go

/******************************************************************************************************/
/*
sp_ejec_strsql
      Realiza un exec.
      PARAMETRO: StrSql S(600)
*/
Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_ejec_strsql')
  Drop Procedure sp_ejec_strsql
Go 
CREATE PROCEDURE sp_ejec_strsql
   @S_600_strsql varchar(600)
 
AS 
--ejecuta la consulta que le envio por parametro desde el cliente
exec (@S_600_strsql)
Go

/******************************************************************************************************/
/*
sp_helptabla
      Genera un Script de Creación para una Tabla.
      PARAMETRO: Tbl S(200)
*/
Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_helptabla')
  Drop Procedure sp_helptabla
Go 
CREATE PROCEDURE sp_helptabla
    @S_200_tbl varchar(200) = '%'
As
Declare @M1 Int , @M2 Int , @M3 Int , @M4 Int
Set NoCount On
Select @S_200_tbl = RTrim( LTrim( @S_200_tbl ) )
If Not Exists ( Select 1
                  From SysObjects
                 Where Name  = @S_200_tbl
                   And XType = 'U'  )
  Begin
    Exec pkt @S_200_tbl
    Return
  End
Create Table #TmpTbl (
  Campos         Char(100) ,
  Tipo_de_Datos  Char(15)  ,
  Longitud       Char(10)  ,
  Decimales      Char(10)  ,
  Permite_Nulos  Char(2)   ,
  Clave_Primaria Char(1)   ,
  Foreign_Key    Char(400) ,
  Referenced_By  Char(400) ,
  Ident          Integer Identity )
Insert Into #TmpTbl
  exec descr @S_200_tbl
Select @M1 = Max( Len( Campos        ) )
     , @M2 = Max( Len( Tipo_de_Datos ) )
     , @M3 = Max( Len( Longitud      ) )
     , @M4 = Max( Len( Decimales     ) )
  From #TmpTbl
Print 'Use ' + db_name()
Print 'G' + 'o'
Print 'If Exists ( Select 1 From SysObjects Where Name = ''' + @S_200_tbl + ''' )'
Print '  Drop Table ' + @S_200_tbl
Print 'G' + 'o'
Print 'Create Table ' + @S_200_tbl + ' ('
Select '      ' + Left( Campos        , @M1 ) + '  '
                + Left( Tipo_de_Datos , @M2 ) 
                + Case 
                    When Tipo_de_Datos =    '%DateTime%' Then Replicate(' ' , (@M3 + @M4 + 3) )
                    When Tipo_de_Datos =    'TimeStamp'  Then Replicate(' ' , (@M3 + @M4 + 3) )
                    When Tipo_de_Datos like '%Int%'      Then Replicate(' ' , (@M3 + @M4 + 3) )
                    When Tipo_de_Datos =    'Bit'        Then Replicate(' ' , (@M3 + @M4 + 3) )
                    Else  '(' + Right( Replicate(' ' , @M3) + RTrim(Longitud) , @M3 )
                              + Case Decimales
                                  When '' Then Replicate( ' ' , @M4 + 1 )
                                  Else ',' + Left( Decimales , @M4 )
                                End
                              + ')'
                  End + ' '
                + Case Permite_Nulos
                    When 'SI' Then 'Null'
                    Else 'Not Null'
                  End
                + Case
                    When Ident = ( Select Max( Ident ) From #TmpTbl ) Then ' )'
                    Else ' ,'
                  End
  From #TmpTbl
If Exists ( Select 1 From #TmpTbl Where Clave_Primaria = 'X' )
  Begin
    Select @M1 = Max( Len( Campos ) )
      From #TmpTbl
     Where Clave_Primaria = 'X'
    Print 'Alter Table ' + @S_200_tbl + ' Add Primary Key ('
    Select Left( Campos , @M1 )
         + Case
             When Ident = ( Select Max( Ident ) From #TmpTbl Where Clave_Primaria = 'X' ) Then ' )'
             Else ' ,'
           End
      From #TmpTbl
     Where Clave_Primaria = 'X'
  End
Print 'G' + 'o'
If Exists ( Select 1 From #TmpTbl Where Foreign_Key != '' )
  Begin
    Print ' Ojo, la Tabla Tiene Foreign Keys : '
    Select Left( Campos , @M1 ), Foreign_Key
      From #TmpTbl
     Where Foreign_Key != ''
  End
If Exists ( Select 1 From #TmpTbl Where Referenced_By != '' )
  Begin
    Print ' Ojo, la Tabla Es Referenciada por otras : '
    Select Left( Campos , @M1 ), Referenced_By
      From #TmpTbl
     Where Referenced_By != ''
  End
Go

/******************************************************************************************************/
/*
sp_helptexto

Muestra el código de un SP.
O busca un SP por nombre.
O busca los SPs q' incluyan cierta palabra.
O una palabra dentro de un SP.
PARAMETROS: Sp  S(200) [DEFAULT = '']
	    Nombre del SP ( o string a buscar en los nombres de los SPs )
	  Bp  S(200) [DEFAULT = '0']
	    Si Bp = 0 y Sp no existe, busca los sps con nombre parecido a @Sp
	    Si Bp = 1 y Sp no existe, busca los sps q' contengan en su código @Sp
	    Si No Busca @Bp en el código de @Sp
	  Cl  I(10)  [DEFAULT = 0]
	    Si Cl = 0 y Bp <> 0 y Bp <> 1 ; muestra una línea en la q' dice si @Sp contiene @Bp
	    Si Cl > 0 y Bp <> 0 y Bp <> 1 ; muestra @Cl líneas a partir de cada aparición de @Bp en @Sp
*/

Go 

/******************************************************************************************************/
/*
sp_LlePar
      Escribe una ejecución standard de un SP.
      PARAMETRO: Nom_Sp S(500) [DEFAULT = Sp_Llepar]
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_LlePar')
  Drop Procedure sp_LlePar
Go 
CREATE PROCEDURE sp_LlePar
           @S_500_nom_sp Varchar(500) = 'sp_LlePar'
As
Declare @Campo varchar(100) ,
        @Tipo  varchar(20)  ,
        @Long  varchar(5)   ,
        @Final varchar(1000),
        @Defol varchar(500) ,
        @Oupu  varchar(6)   ,
        @Dec   varchar(5)   ,
        @Id    Int
If Not Exists ( Select 1 From SysObjects Where Name = @S_500_nom_sp )
  Begin
    Exec sp_helptexto @S_500_nom_sp
    Return 1
  End
Set NoCount On
Create Table #TDesc ( Campo  varchar(100) ,
                      Tipo   varchar(20)  ,
                      Long   VarChar(5)   ,
                      Dec    VarChar(5)   ,
                      Nulo   Varchar(2)   ,
                      PK     Varchar(1)   ,
                      FK     Varchar(500) ,
                      RB     Varchar(500) ,
                      Iden   Int Identity )
Print '/*'
Insert Into #TDesc
  Exec Descr @S_500_nom_sp
Print '*/'
Create Table #TTxt ( Texto varchar (2000) , Iden Int Identity )
Create Table #TFin ( Campo varchar (500) , Comentario Varchar(50) , Iden Int Identity )
Insert Into #TFin Select 'Exec ' + @S_500_nom_sp , ''
Declare Cu Cursor Local Fast_Forward For
  Select Campo , Tipo , Long , Dec , Iden
    From #TDesc
Open Cu
While 1=1
  Begin
    Fetch Cu Into @Campo , @Tipo , @Long , @Dec , @Id
    If @@Fetch_Status != 0 Break
    Delete From #TTxt
    Insert Into #TTxt
      Exec sp_helptext @S_500_nom_sp
    Delete From #TTxt Where Iden != ( Select Min( Iden ) From #TTxt Where Texto Like '%' + @Campo + '%' )
    Select @Final = '' , @Defol = '' , @Oupu = ''
    Select @Defol = Case
                      When Texto Like '%=%' Then SubString(  Texto
                                                           , CharIndex( '=' , Texto ) + 1
                                                           , 500
                                                           )
                      Else ''
                    End
      From #TTxt
    If @Defol = ''
      Select @Oupu = Case
                       When Texto Like '%output%' And Texto Not Like '%--%output%' Then 'output'
                       Else ''
                     End
        From #TTxt
            
    Insert Into #TFin
             Select @Campo + ' = ' + Case
                                       When @Defol != '' Then @Defol
                                       Else Case
                                              When @Campo Like '%Trans%'             Then '0'
                                              When @Campo Like '%Repro%'             Then '0'
                                              When @Campo Like '%nom_sp%'            Then '''' + @S_500_nom_sp + ''''
                                              When @Campo Like '%sec_arch%'          Then '''1'''
                                              When @Campo Like '%arch%'              Then ''''
                                                                                        + (  Select Top 1 nom_arch
                                                                                               From AdArchivos
                                                                                              Where nom_sp_arch = @S_500_nom_sp )
                                                                                        + ''''
                                              When @Campo Like '%login%'             Then '''LOGIN'''
                                              When @Campo Like '%adm%'               Then IsNull(  (  Select Top 1 Str( cod_adm , 2 )
                                                                                                        From AdAdMinistradoras
                                                                                                       Where Abrev_Adm = Right( @S_500_nom_sp , 2 ) )
       , 0
                                                                                                 )
                                              When @Campo Like '%GeneraLog%'         Then '1'
                                              When @Tipo = 'Numeric'                 Then '0'
                                              When @Tipo Like '%Int%'                Then '0'
                                              When @Tipo Like '%Char'                Then ''''''
                                              When @Tipo Like '%Date%'               Then ''''
                                                                                        + Convert(  Varchar(20)
                                                                                                  , ( Select FecSis From Gyf_empresa )
                                                                                                  , 120
                                                                                                  )
                                                                                        + ''''
                                            End
                                     End + ' ' + @oupu + Case
                                                           When @Id = ( Select Max( Iden ) From #TDesc ) Then ''
                                                           When @Defol != '' Then ''
                                                           Else ','
                                                         End As Campo
                  , ' /* ' + @Tipo + Case @Long
                                        When '' Then ''
                                        Else '(' + @Long + Case @Dec
                                                             When '' Then ''
                                                             Else ',' + @Dec
                                                           End + ')'
                                     End + Case @Defol
                                             When '' Then ''
                                             Else ' ES UN VALOR DEFAULT!!'
                                           End + '*/' As Comentario
  End
Select Comentario as 'Set NoCount On' , Campo As ' ' From #TFin Order by Iden
Close Cu
Deallocate Cu
Drop Table #TDesc , #TTxt
Go

/******************************************************************************************************/
/*
sp_val_actividad [DEPRECATED]
      Es algo así como un Alias para sp_Who 'active'.
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_actividad')
  Drop Procedure sp_val_actividad
Go 
 
 
CREATE PROCEDURE sp_val_actividad as
select spid,blocked as blk,
       last_batch,
        substring(hostname,1,15) as hostname,
        cpu,
        physical_io,
        memusage, 
        substring(program_name,1,20) as prg_name,cmd 
  from master..sysprocesses 
 where status = 'runnable'
Go


/******************************************************************************************************/
/*
sp_val_arma_declares
Arma una lista de declares para variables q' coinciden con los campos de una tabla.
PARAMETROS: Tabla S(200)
	  Arrob S(10)  [DEFAULT = '@']
	  Los nombres de las variables serán @Arrob@Tabla
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_arma_declares')
  Drop Procedure sp_val_arma_declares
Go 
CREATE PROCEDURE sp_val_arma_declares
  @S_200_tabla varchar(200),
  @S_10_arrob varchar(10) = '@'
as
-- FB: 22/9/2000: Acepta nulos en @S_10_arrob
declare @Aux as numeric(5)
set nocount on
print 'SP_VAL_ARMA_DECLARES: (Ultima Actualizacion = 22/9/2000)'
print 'Declaracion de variables para tabla: ' + upper(@S_200_tabla)
print 'Con formato: ' + @S_10_arrob + 'Campo'
print ''
set @Aux = 0
select @Aux = max(len(b.name))
from sysobjects a,syscolumns b
 where a.id=b.id  and a.name=@S_200_tabla
print '-- ' + @S_200_tabla + ':'
select 'declare ' + @S_10_arrob + b.name + replicate(' ',@Aux - len(b.name)) + ' as ' + type_name(b.xtype)
 + case b.xtype
            when 61 then ' '
            else '(' + case convert(varchar(2),xprec)
    when 0 then convert(varchar(3),length)
      else case xscale
    when 0 then convert(varchar(2),xprec)
    else convert(varchar(2),xprec) + ',' + convert(varchar(2),xscale)
        end
         end
              + ')' 
   end
from sysobjects a,syscolumns b
 where a.id=b.id  and a.name=@S_200_tabla
 order by a.id
set nocount off
return 0
Go

/******************************************************************************************************/
/*
sp_val_arma_declares_alf
      Idem sp_val_arma_declares pero con los campos ordenados alfabeticamente.

*/
Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_arma_declares_alf')
  Drop Procedure sp_val_arma_declares_alf
Go 
 
CREATE PROCEDURE sp_val_arma_declares_alf
  @S_200_tabla varchar(200),
  @S_10_arrob varchar(10) = '@'
as
declare @Aux as numeric(5)
set @Aux = 0
print 'SP_VAL_ARMA_DECLARES_ALF: (Ultima Actualizacion = 6/10/2000)'
print 'Declaracion de variables en orden alfabetico para tabla: ' + upper(@S_200_tabla)
print 'Con formato: ' + @S_10_arrob + 'Campo'
print ''
select @Aux = max(len(b.name))
from sysobjects a,syscolumns b
 where a.id=b.id  and a.name=@S_200_tabla
print '-- ' + @S_200_tabla + ':'
select 'declare ' + @S_10_arrob + b.name + replicate(' ',@Aux - len(b.name)) + ' as ' + type_name(b.xtype) 
 + case b.xtype
            when 61 then ' '
            else '(' + case convert(varchar(2),xprec)
    when 0 then convert(varchar(3),length)
      else case xscale
    when 0 then convert(varchar(2),xprec)
    else convert(varchar(2),xprec) + ',' + convert(varchar(2),xscale)
        end
         end
              + ')' 
   end
from sysobjects a,syscolumns b
 where a.id=b.id  and a.name=@S_200_tabla
 order by b.name asc
Go

/*****************************************************************************************************/
/*
sp_val_arma_declares_gde
Arma una lista de declares para variables q' coinciden con los campos de una tabla,
agregandole un número fijo a las longitudes de los mismos.
PARAMETROS: Arrob S(10)
	  Tabla S(200)
	  Taman N(5)   
	  Los nombres de las variables serán @Arrob@Tabla
	  y el tamaño será el tamaño original + Taman
*/
Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_arma_declares_gde')
  Drop Procedure sp_val_arma_declares_gde
Go 
 
CREATE PROCEDURE sp_val_arma_declares_gde
  @S_10_arrob varchar(10),
  @S_200_tabla varchar(200),
                @N_5_taman numeric(5)
as
declare @Aux as numeric(5)
set @Aux = 0
select @Aux = max(len(b.name))
from sysobjects a,syscolumns b
 where a.id=b.id  and a.name=@S_200_tabla
print '-- ' + @S_200_tabla + ':'
select 'declare ' + @S_10_arrob + b.name + replicate(' ',@Aux - len(b.name)) + ' as ' + type_name(b.xtype) 
 + case b.xtype
            when 61 then ' '
            else '(' + case xprec
    when 0 then str((length + @N_5_taman),3)
      else case xscale
    when 0 then str((xprec + @N_5_taman),2)
    else str((xprec + @N_5_taman),2) + ',' + str(xscale,2)
        end
         end
              + ')' 
   end
from sysobjects a,syscolumns b
 where a.id=b.id  and a.name=@S_200_tabla
 order by a.id
Go

/******************************************************************************************************/
/*
sp_val_as_cpo_cpo
Escribe Select, Insert o UpDate de una tabla.
PARAMETROS: Tabla S(200)
  Alias S(10)  [DEFAULT = ' ']
    Si Alias no es ' ', las campos se nombraran @AliasCampo
  Uso   S(1)   [DEFAULT = 'S']
    S = Select
    U = UpDate
    I = Insert
    Titu  N(1)   [DEFAULT = 1]
    1 = Imprime títulos
    0 = No Imprime títulos
P - Parametros (Escribe los campos de la tabla con el formato de parámetros para un Sp)
V - Insert Values (Escribe la lista de Insert ... Values... con formato de parámetros)
L - Values (Sólo escribe los Values (.....)  con formato de parámetros)
*/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_as_cpo_cpo')
  Drop Procedure sp_val_as_cpo_cpo
Go 
CREATE PROCEDURE sp_val_as_cpo_cpo
  @S_200_tabla varchar(200),
  @S_10_alias varchar(10) = ' ',
                @S_1_uso   varchar(1) = 'S', --'S' = Select ; 'U' = Update ; 'I' = Insert
                @N_1_titu  numeric(1)  = 1
as
declare @Aux  as numeric(5)
declare @Aux4 as numeric(1)
declare @Auxs as varchar(200)
declare @Auxs2 as varchar(100)
declare @i     as integer
declare @nCant as integer
set @Aux  = 0
set @Aux4 = 0
If @N_1_titu = 1
  Begin
    print 'SP_VAL_AS_CPO_CPO: (Ultima Actualizacion = 26/4/2001)'
    print 'Selecciona campos de tabla: ' + upper(@S_200_tabla)
    print 'Con alias: ' + @S_10_alias + 'Campo'
    print ''
  End
If @S_1_uso not in ('S' , 'U' , 'I')
  Begin
    Print 'Uso Incorrecto: ' + @S_1_uso
    Print 'Usos Correctos: S - Select'
    Print '                U - Update'
    Print '                I - Insert'
  End
select @Aux   = max(len(b.name))
     , @nCant = count(*)
from sysobjects a,syscolumns b
 where a.id=b.id and a.name=@S_200_tabla
declare cu cursor local forward_only read_only for
  select Case @S_1_uso
           When 'S' Then @S_10_alias
           Else ' '
         End + b.name + replicate(' ',@Aux - len(b.name)) + case @S_1_uso
                                                              When 'U' Then ' = && , '
                                                              Else ', '
                                                            end
    from sysobjects a,syscolumns b
   where a.id=b.id and a.name=@S_200_tabla
order by b.colid
open cu
If @S_1_uso = 'U'
  Print 'Update ' + db_name() + '..' + @S_200_tabla + ' Set'
If @S_1_uso = 'I'
  Print 'Insert Into ' + db_name() + '..' + @S_200_tabla + ' ('
If @S_1_uso = 'S'
  Print 'Select '
If @S_1_uso = 'U'
  Begin
    While 1=1 begin
      fetch cu into @Auxs
      if @@Fetch_Status <> 0 Break
      Set @i = IsNull(@i , 0) + 1
      Set @Auxs = '       ' + @Auxs
      print Case @i
              When @nCant Then Left( @Auxs , Len(@Auxs) - 1 )
              Else @Auxs
            End
    End
  End
Else
  Begin
    while 1=1 begin
      fetch cu into @Auxs
      if @@fetch_status <> 0 break
      Set @i = IsNull(@i , 0) + 1
      if @Aux4 = 0 begin
        set @Aux4 = 1
        set @Auxs2 = '       '
      end
      set @Auxs2 = @Auxs2 + @Auxs
      if len(@Auxs2) >= (89 - @Aux) begin
        print Case @i
                When @nCant Then substring(@Auxs2,1,len(@Auxs2)-1)
                Else @Auxs2
              End
        set @Auxs2 = '       '
      end
    end
    If @Auxs2 <> '' print substring(@Auxs2,1,len(@Auxs2)-1)
  End
close cu
deallocate cu
If @S_1_uso = 'S'
  Begin
    print '  from ' + db_name() + '..' + @S_200_tabla + case
                                                    when @S_10_alias = '' then ''
                                                    else ' ' + substring(@S_10_alias,1,len(@S_10_alias)-1)
                                                  end
  End
If @S_1_uso = 'I'
  Begin
    print ')'
    Exec sp_val_as_cpo_cpo @S_200_tabla, @S_10_alias, 'S', 0
  End
Go

/******************************************************************************************************/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_busca_palabra')
  Drop Procedure sp_val_busca_palabra
Go 
CREATE PROCEDURE sp_val_busca_palabra @S_128_Sword  varchar(128)
as
--Stored que busca una palabra dentro de todos los stored de la base corriente
-- GCJ: 29/08/2000: verifica que los SP aparezcan una sola vez
declare @S_128_SwordLike varchar(128)
set @S_128_SwordLike = '%' + @S_128_Sword + '%'  
 
print 'Lista de Stored conteniendo la palabra "' +  @S_128_Sword + '"'
print ''
select distinct name as Stored_Procedures  
  from sysobjects
 inner join syscomments on sysobjects.id = syscomments.id
 where syscomments.text like @S_128_SwordLike
 order by Stored_Procedures
Go

/******************************************************************************************************/
Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_busca_sp')
  Drop Procedure sp_val_busca_sp
Go 
CREATE PROCEDURE sp_val_busca_sp @S_100_SP varchar(100)=null
as
declare @S_100_SP_Aux as varchar(100)
set @S_100_SP_Aux = '%' + @S_100_SP + '%'
if @S_100_SP is null
  begin
    print 'Utilizacion de Stored Procedure SP_VAL_BUSCA_SP:
           @S_100_SP varchar(100) REQUERIDO'
    return -166
  end
if exists(select 1 from sysobjects where name like @S_100_SP_Aux and xtype = 'P' and category=0)
begin
  print 'Lista de Stored Procedures con nombre conteniendo "' + @S_100_SP + '"'
  print ''
  select convert(varchar(30),name) as Nombre,id as ID_SP ,crdate as Fecha_creacion 
  from sysobjects 
  where name like @S_100_SP_Aux and xtype = 'P' and category=0
end
else
  print 'No existen Stored Procedures con nombre conteniendo "' + @S_100_SP + '"'
return 0
Go


/******************************************************************************************************/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_busca_tabla1')
  Drop Procedure sp_val_busca_tabla1
Go 
CREATE PROCEDURE sp_val_busca_tabla1 @S_100_Tabla varchar(100)=null
as
declare @S_100_Tabla_Aux as varchar(100)
set @S_100_Tabla_Aux = '%' + @S_100_Tabla + '%'
if @S_100_Tabla is null
  begin
    print 'Utilizacion de Stored Procedure SP_VAL_BUSCA_TABLA1:
           @S_100_Tabla varchar(100) REQUERIDO'
    return -166
  end
if exists(select 1 from sysobjects where name like @S_100_Tabla_Aux and xtype = 'P' and category=0)
begin
  print 'Lista de tablas con nombre conteniendo "' + @S_100_Tabla + '"'
  print ''
  select convert(varchar(30),name) as Nombre,id as ID_Tabla ,crdate as Fecha_creacion 
  from sysobjects 
  where name like @S_100_Tabla_Aux and xtype = 'P' and category=0
end
else
  print 'No existen Tablas con nombre conteniendo "' + @S_100_Tabla + '"'
return 0
Go

/*****************************************************************************************************/


Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_CampoEnTablas')
  Drop Procedure sp_val_CampoEnTablas
Go 
CREATE PROCEDURE sp_val_CampoEnTablas @S_30_Campo as varchar(30) as
-- Devuelve en que tablas se encuentra el campo indicado (acepta metacaracteres)
select a.name as Tablas
  from sysobjects a,
       syscolumns b
 where a.id=b.id 
   and a.xtype='U'
   and b.name like @S_30_Campo
Go

/******************************************************************************************************/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_descr_tipo_arch')
  Drop Procedure sp_val_descr_tipo_arch
Go 
CREATE PROCEDURE sp_val_descr_tipo_arch
                    @S_200_tabla varchar(200)
as
    -- Genera una descripcion de la tabla en formato de archivo de registros (TXT)
    declare @n as varchar(25),
            @l as numeric(5),
            @a as numeric(5)
    declare cu cursor local forward_only read_only for
               select name, length from syscolumns where 
                                                    object_name(id) = @S_200_tabla
                                                    and type_name(xtype) like '%char%'
    
    open cu
    set @a = 1
    print 'Nombre                    Posic. Tamanio'
    print '---------------------------------------'
    while 1=1 begin
        fetch cu into @n, @l
        if @@fetch_status <> 0 break
        print @n + replicate('.', 26 - len(@n)) + str(@a,5)+ ' ' + str(@l,5)
        set @a = @a + @l
    end
    close cu
    deallocate cu
    print 'LARGO TOTAL ------------->' + str(@a - 1,5)
Go

/******************************************************************************************************/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_genera_alter')
  Drop Procedure sp_val_genera_alter
Go 
 

CREATE PROCEDURE sp_val_genera_alter @S_40_Tabla varchar(40) as
declare @tabla_id numeric(15)
declare @campo1   varchar(40)
declare @campo2   varchar(40)
declare @tipo1    varchar(40)
declare @long1    varchar(40)
declare @prec1    varchar(40)
declare @null1    varchar(40)
declare @pk1      varchar(40)
declare @tipo2    varchar(40)
declare @long2    varchar(40)
declare @prec2    varchar(40)
declare @null2    varchar(40)
declare @pk2      varchar(40)
--Veo si existe la tabla en destino
if not exists (select 1 from sysobjects where object_name(id)=@S_40_Tabla)
  begin
    print '--No existe la tabla ' + @S_40_Tabla
    return 
  end
-- Se obtienen los campos que se deben agregar
declare cu_tmp cursor local forward_only read_only for
 select a.name,b.name,t.name,
           case 
              when t.name = 'numeric' then convert(varchar(10),a.xprec)
              else convert(varchar(10),a.length)
           end,
           case 
              when a.xscale > 0 and t.name <> 'datetime' then  ',' + convert(varchar(3),a.xscale)
              else ' '
           end,
           case a.isnullable 
              when 1 then ''
              else ' -- OJO: Not null'
           end,
           case
              when a.colid = k.colid then ' -- OJO: PK'
              else ''
           end
   from syscolumns a
        inner join systypes t on (a.xtype=t.xtype)
         left outer join master..syscolumns b 
           on (object_name(a.id)=object_name(b.id) and
               a.name=b.name)
         left outer join sysindexkeys k on
              (a.id = k.id and a.colid = k.colid and k.indid = 1)
  where object_name(a.id)=@S_40_Tabla
open cu_tmp
while 1=1
  begin
    fetch cu_tmp into @campo1,@campo2,@tipo1,@long1,@prec1,@null1,@pk1
    if @@fetch_status<>0
      begin
        break
      end 
    if @campo2 is null
      begin
        --El campo se agrega
        print 'alter table ' + @S_40_Tabla + ' add ' + @campo1 + ' ' + @tipo1 + ' (' + @long1 + ')' + @null1 + @pk1
      end
  end
close cu_tmp
deallocate cu_tmp
-- Se obtiene los campos que se deben eliminar
declare cu_tmp cursor local forward_only read_only for
 select a.name,b.name
   from master..syscolumns a
         left outer join syscolumns b 
           on (object_name(a.id)=object_name(b.id) and
               a.name=b.name)
  where object_name(a.id)=@S_40_Tabla
open cu_tmp
while 1=1
  begin
    fetch cu_tmp into @campo1,@campo2
    if @@fetch_status<>0
      begin
        break
      end 
    if @campo2 is null
      begin
        --El campo se elimina
        print 'alter table ' + @S_40_Tabla + ' drop column ' + @campo1 
      end
  end
close cu_tmp
deallocate cu_tmp
-- Se obtienen los campos modificados
declare cu_tmp cursor local forward_only read_only for
 select a.name,t.name,
           case 
              when t.name = 'numeric' then convert(varchar(10),a.xprec)
              else convert(varchar(10),a.length)
           end,
           case 
              when a.xscale > 0 and t.name <> 'datetime' then  ',' + convert(varchar(3),a.xscale)
              else ' '
           end,
           case a.isnullable 
              when 1 then ''
              else ' -- OJO: Not null'
           end,
           case
              when a.colid = k.colid then ' -- OJO: PK'
              else ''
           end,
           x.name,
           case 
              when x.name = 'numeric' then convert(varchar(10),b.xprec)
              else convert(varchar(10),b.length)
           end,
           case 
              when b.xscale > 0 and x.name <> 'datetime' then  ',' + convert(varchar(3),b.xscale)
              else ' '
           end,
           case b.isnullable 
              when 1 then ''
              else ' -- OJO: Not null'
           end,
           case
              when b.colid = l.colid then ' -- OJO: PK'
              else ''
           end
   from syscolumns a
        inner join systypes t on (a.xtype=t.xtype)
        inner join master..syscolumns b 
           on (object_name(a.id)=object_name(b.id) and
               a.name=b.name)
        inner join systypes x on (b.xtype=x.xtype)
         left outer join sysindexkeys k on
              (a.id = k.id and a.colid = k.colid and k.indid = 1)
         left outer join sysindexkeys l on
              (b.id = l.id and b.colid = l.colid and l.indid = 1)
  where object_name(a.id)=@S_40_Tabla
open cu_tmp
while 1=1
  begin
    fetch cu_tmp into @campo1,@tipo1,@long1,@prec1,@null1,@pk1,@tipo2,@long2,@prec2,@null2,@pk2
    if @@fetch_status<>0
      begin
        break
      end 
    if @tipo1+@long1+@prec1+@null1+@pk1<>@tipo2+@long2+@prec2+@null2+@pk2
      begin
        --El campo se modifica
        print 'alter table ' + @S_40_Tabla + ' modify ' + @campo1 + ' ' + @tipo1+ ' (' + @long1 + ')' + @null1 + @pk1
        if @null1<>''
          begin
            -- Pongo valor default y le asigno not null
            print 'update ' + @S_40_Tabla + ' Set ' + @campo1 + ' = ' + case @tipo1
                                                                         when 'numeric' then -1
                                                                         when 'varchar' then '#'
                                                                         when 'datetime' then '1899-01-01'
                                                                         else  'Null'
                                                                    end
            print 'alter table ' + @S_40_Tabla + ' modify ' + @campo1 + ' ' + @tipo1+ ' (' + @long1 + ')' + substring(@null1,9,8) + @pk1
          end
      end
  end
close cu_tmp
deallocate cu_tmp
Go

/******************************************************************************************************/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_pasa_tablas')
  Drop Procedure sp_val_pasa_tablas
Go 
CREATE PROCEDURE sp_val_pasa_tablas (@S_40_tabla_destino as varchar(40),@S_40_tabla_origen as varchar(40)) as
declare @strejec as varchar(200)
print 'begin transaction'
declare cu_curs cursor local fast_forward for
  --Deshabilita las constraints
  select distinct '  alter table ' + object_name(fkeyid) + ' nocheck constraint ' + object_name(constid)
    from sysforeignkeys
   where object_name(rkeyid)=@S_40_tabla_destino
open cu_curs
while 1=1
  begin
    fetch cu_curs into @strejec
    if @@fetch_status<>0 break
    print @strejec
  end
close cu_curs
deallocate cu_curs
print ''
--Borra los registros de la tabla de destino
print '  delete from ' + @S_40_tabla_destino 
print '  if @@error<>0 goto MalTrans'
print ''
--Inserta los registros de la tabla de origen
print '  insert into ' + @S_40_tabla_destino + ' select * from trabajo..' + @S_40_tabla_origen
print '  if @@error<>0 goto MalTrans'
print ''
declare cu_curs cursor local fast_forward for
  -- Habilita las constraints
  select distinct '  alter table ' + object_name(fkeyid) + ' check constraint ' + object_name(constid)
    from sysforeignkeys
   where object_name(rkeyid)=@S_40_tabla_destino
open cu_curs
while 1=1
  begin
    fetch cu_curs into @strejec
    if @@fetch_status<>0 break
    print @strejec
    print '  if @@error<>0 goto malTrans'
    print ''
  end
close cu_curs
deallocate cu_curs
print ''
declare cu_curs cursor local fast_forward for
  -- Fuerza el checkeo de constraints
  select '  update ' + object_name(fkeyid) + 
             ' set ' + col_name(fkeyid,fkey) + 
                 '=' + col_name(fkeyid,fkey) 
    from sysforeignkeys
   where object_name(rkeyid)=@S_40_tabla_destino
open cu_curs
while 1=1
  begin
    fetch cu_curs into @strejec
    if @@fetch_status<>0 break
--    print @strejec
--    print '  if @@error<>0 goto malTrans'
--    print ''
  end
close cu_curs
deallocate cu_curs
print '  commit transaction'
print ''
print 'print OK'
print '  goto fin'
print 'malTrans:' 
print '  rollback transaction'
print 'print " ERROR!!!!!!!"'
print 'fin:'
Go

/******************************************************************************************************/

Go 
If Exists ( Select 1 From SysObjects Where Name = 'SP_Val_PasaTabla')
  Drop Procedure SP_Val_PasaTabla
Go 
CREATE PROCEDURE SP_Val_PasaTabla
                      @S_200_Tbl Varchar(200) = '', @S_200_Where Varchar(200) = '', @N_1_Pr numeric(1) = 0
As
Declare @Ins varchar(4000)
Declare @BIns numeric(1)
Declare @Sel varchar(5000)
Declare @Name as varchar(70)
Declare @Type as varchar(20)
If 0 = (Select Count(*)   From SysColumns
         Where Object_Name(id) = @S_200_Tbl
           And Id In (Select Id 
                        From SysObjects
                       Where XType = 'U' 
                         And (   Name like 'AD%' 
                              Or Name Like 'GYF%') ) )
  Begin
    Print 'No Existen Tablas Con Nombre ''' + @S_200_Tbl + '''.'
    Return
  End
Declare Cu Cursor Local Forward_Only Read_Only For
Select substring(name, 1, 70), type_name(xtype)
  From SysColumns
 Where Object_Name(id) = @S_200_Tbl
   And Id In (Select Id 
                From SysObjects
               Where XType = 'U' 
                 And (   Name like 'AD%' 
                      Or Name Like 'GYF%') )
 Order By Colid
Open Cu
Select @Ins = 'Insert Into ' + @S_200_Tbl + ' ( '
Select @BIns = 0
While 1=1
  Begin
    Fetch Cu Into
      @Name, @Type
    If @@Fetch_Status <> 0 Break
    Select @Ins = @Ins + @Name + ' , '
    If (Len(@Ins) % 200 ) between -15 and 15
      Select @Ins = @Ins + ''', ''
                                '
  End
Close Cu
Select @Ins = SubString( @Ins, 1, Len(@Ins) - 2) + ') 
          Values ('
Select @Sel = 'Select ''' + @Ins + ''' , '
Open Cu
While 1=1
  Begin
    Fetch Cu Into
      @Name, @Type
    If @@Fetch_Status <> 0 Break
    Select @Sel = @Sel + Case
                           When @Type In ('Char', 'Varchar' ) Then ''''''''' + ' + @Name + ' + '''''''' As ' + @Name
                           When @Type In ('DateTime')  Then ''''''''' + Convert(Varchar(20), ' + @Name + ', 20 ) + '''''''' As ' + @Name
                           When @Type In ('TimeStamp') Then 'Null As ' + @Name
                           Else @Name
                         End + ' , '','' , '
  End
Select @Sel = SubString( @Sel , 1 , Len(@Sel) - 4 ) + ')'' From ' + @S_200_Tbl + ' ' + @S_200_Where
If @N_1_Pr = 1 Print @Sel
Print 'Delete From ' + @S_200_Tbl + ' ' + @S_200_Where
Exec ( @Sel )
Close Cu
DeAllocate Cu
Go

/******************************************************************************************************/
If Exists ( SELECT 1 FROM SysObjects WHERE Name = 'sp_whom_vcampos')  
    DROP Procedure sp_whom_vcampos
Go 
Create Procedure [dbo].[sp_whom_vcampos]
                    @S_2000_campos varchar(2000) output
As
--Stored Interno de GYF para Sp_Whom
Declare
  @nPos Integer,
  @Char char(1),
  @nCom numeric(4),
  @nPto numeric(4),
  @nSpc numeric(4)
If     @S_2000_campos Not Like 'a.%'
   And @S_2000_campos not like 'distinct %'
  Begin
    Print 'CUIDADO: @S_2000_campos comienza con ' + Left(@S_2000_campos,2)
    Set @S_2000_campos = 'A.*'
    Return
  End
Set @nPos = 0
While @nPos < Len(@S_2000_campos)
  Begin
    Set @nPos = @nPos + 1
    Select @Char = SubString(@S_2000_campos, @nPos , 1)
    If @Char = ' ' And ( SubString( @S_2000_campos, @nPos + 1 , 1 ) Not In ( ' ' , ',' , 'A' ) )
      Begin
        Print 'CUIDADO: En @S_2000_campos hay un espacio seguido de ' + SubString( @S_2000_campos, @nPos + 1 , 1 ) 
            + ' en la posicion ' + str(@nPos,4)
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char Not In ( ' ' , ',' ) And SubString( @S_2000_campos, @nPos + 1 , 1 ) = ' ' And SubString( @S_2000_campos, @nPos - 1 , 1 ) = ' '
      Begin
        Print 'CUIDADO: En @S_2000_campos hay un ' + @Char + ' entre espacios en la posicion ' + str(@nPos,4)
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char Not In ( ' ' , ',' ) And SubString( @S_2000_campos, @nPos + 1 , 1 ) = ',' And SubString( @S_2000_campos, @nPos - 1 , 1 ) = ','
      Begin
        Print 'CUIDADO: En @S_2000_campos hay un ' + @Char + ' entre comas en la posicion ' + str(@nPos,4)
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char Not In ( ' ' , ',' ) And SubString( @S_2000_campos, @nPos + 1 , 1 ) = ' ' And SubString( @S_2000_campos, @nPos - 1 , 1 ) = ','
      Begin
        Print 'CUIDADO: En @S_2000_campos hay un ' + @Char + ' entre coma y espacio en la posicion ' + str(@nPos,4)
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char = ',' And @nPos = Len(@S_2000_campos)
      Begin
        Print 'CUIDADO: En @S_2000_campos hay una coma al final.'
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char = ',' And ( SubString( @S_2000_campos, @nPos + 1 , 1 ) Not In ( ' ' , 'A' ) )
      Begin
        Print 'CUIDADO: En @S_2000_campos hay una coma seguida de ' + SubString( @S_2000_campos, @nPos + 1 , 1 ) 
            + ' en la posicion ' + str(@nPos,4)
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char = '.' And @nPos = Len(@S_2000_campos)
      Begin
        Print 'CUIDADO: En @S_2000_campos hay un punto al final.'
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char = '.' And ( SubString( @S_2000_campos, @nPos - 1 , 1 ) <> 'A' )
      Begin
        Print 'CUIDADO: En @S_2000_campos hay un punto precedido por ' + SubString( @S_2000_campos, @nPos - 1 , 1 ) 
            + ' en la posicion ' + str(@nPos,4)
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char = '.' And ( SubString( @S_2000_campos, @nPos + 1 , 1 ) In ( ' ' , ',' ) )
      Begin
        Print 'CUIDADO: En @S_2000_campos hay un punto Seguido por ' + SubString( @S_2000_campos, @nPos + 1 , 1 ) 
            + ' en la posicion ' + str(@nPos,4)
        Set @S_2000_campos = 'A.*'
        Break
      End
    If @Char In ( '|' , '/' , '&' , '%' , '?' , '¨' , '(' , ')' , '$' , '#' , '"' , '=' , '!' , 'ï' , '''' ,
                  '+' , '{' , '}' , '[' , ']' , '~' , '^' , '`' , '-' , ':' , ';' , '<' , '>' , '@' , 'ù'  )
      Begin
        Print 'CUIDADO: En @S_2000_campos hay un caracter invalido (' + @Char + ') En la Posicion ' + str(@nPos,4)
        Set @S_2000_campos = 'A.*'
        Break
      End
  End
go
/*************************************************************************************************************/

If Exists ( Select 1 From SysObjects Where Name = 'sp_whoMAll')
  Drop Procedure sp_whoMAll
Go 
CREATE PROCEDURE sp_whoMAll  --- 1995/11/03 10:16
--    @S_200_loginame     sysname = NULL
      @S_200_loginame     varchar(200) = '%',
      @S_2000_campos       varchar(2000) = 'A.*',
      @N_1_muestroyo    numeric(1) = 0
as
/*************************************************************************************************************
**        Este SP es como el Sp_WhoM , pero muestra absolutamente todos los sps.                              
**        (13/08/2001)                                                                                        
**                                                                                   Fernando                 
**                                                                                   Benavides                
**************************************************************************************************************/
/*************************************************************************************************************
** Parametros:                                                                                                
**   @S_200_loginame : Una palabra a buscar en cualquiera de los campos que devuelve el Stored                      
**               Funciones Especiales : Active = 'Not Sleeping'                                               
**               Local / Remote : 'Host_Name()' / 'Not Host_Name()'                                           
**               Act Db : 'db_name()'                                                                         
**               --> Si @S_200_loginame = 'Not %'; Busca que los campos sean diferentes a @S_200_loginame - 'Not'         
**                                                                                                            
**   @S_2000_campos   : Campos que debe devolver el Stored ( El Default son Todos )                                  
**               Deben escribirse precedidos de una a y un punto y separados por comas                        
**                                                                                                            
**   @N_1_muestroyo: Determina si el stored muestra el proceso desde el cual esta siendo invocado                 
**               O sea , si se muestra a si mismo.  ( El Default es No )                                      
**                                                                                                            
**                                                                                   Fernando                 
**                                                                                   Benavides                
**************************************************************************************************************/
set nocount on
declare
    @retcode         int
declare
    @sidlow         varbinary(85)
   ,@sidhigh        varbinary(85)
   ,@sid1           varbinary(85)
   ,@spidlow         int
   ,@spidhigh        int
declare
    @charMaxLenLoginName      varchar(6)
   ,@charMaxLenUserName       varchar(6) --FB: 2001-05-21
   ,@charMaxLenDBName         varchar(6)
   ,@charMaxLenCPUTime        varchar(10)
   ,@charMaxLenDiskIO         varchar(10)
   ,@charMaxLenHostName       varchar(10)
   ,@charMaxLenProgramName    varchar(10)
   ,@charMaxLenLastBatch      varchar(10)
   ,@charMaxLenCommand        varchar(10)
declare
    @charsidlow               varchar(85)
   ,@charsidhigh              varchar(85)
   ,@charspidlow              varchar(11)
   ,@charspidhigh             varchar(11)
declare
    @Not                      varchar(3),
    @sMuestroYo               varchar(20)
--------
--Campos:
Set @S_2000_campos = LTrim( RTrim( @S_2000_campos ) )
If len(@S_2000_campos) < 3
  Begin
    Print 'CUIDADO: @S_2000_campos demasiado corto'
    Set @S_2000_campos = 'A.*'
  End
If @S_2000_campos <> 'A.*'
  Begin
    If CharIndex(' ', @S_2000_campos , 0 ) > 0 Or CharIndex(',' , @S_2000_campos , 0 ) > 0
      Begin
        Exec sp_whom_vcampos @S_2000_campos output
      End
    Else
      Begin
        If Left(@S_2000_campos,2) <> 'A.'
          Begin
            Print 'CUIDADO: Los nombres de los campos deben empezar con A.'
            Set @S_2000_campos = 'A.*'
          End
      End
  End
--------
--MuestroYo:
Select @sMuestroYo = Case
                       When @N_1_muestroyo = 0 Then ' and Spid != @@Spid '
                       Else ''
                     End
--Funciones Especiales:
If @S_200_loginame = 'Active'           Select @S_200_loginame = 'not sleeping'
If @S_200_loginame = 'Not Active'       Select @S_200_loginame = 'sleeping'
If @S_200_loginame = 'Local'            Select @S_200_loginame = host_name()
If @S_200_loginame = 'Not Local'        Select @S_200_loginame = 'not ' + host_name()
If @S_200_loginame = 'Remote'           Select @S_200_loginame = 'not ' + host_name()
If @S_200_loginame = 'Not Remote'       Select @S_200_loginame = host_name()
If @S_200_loginame = 'Act db'           Select @S_200_loginame = db_name()
If @S_200_loginame = 'Not Act db'       Select @S_200_loginame = 'not ' + db_name()
If @S_200_loginame like 'N%S%/%N%C'     Select @S_200_loginame = 'N S / N C'
If @S_200_loginame like 'Not N%S%/%N%C' Select @S_200_loginame = 'Not N S / N C'
--Si Loginame es 'Not %' ==> !=
If Len(@S_200_loginame) > 4 And @S_200_loginame like 'Not %'
  Begin
    Select @Not      = 'Not'
    Select @S_200_loginame = SubString( @S_200_loginame , 5 , 100 )
  End
Else
  Select @Not = ''
select
    @retcode         = 0      -- 0=good ,1=bad.
--------defaults
select @sidlow = convert(varbinary(85), (replicate(char(0), 85)))
select @sidhigh = convert(varbinary(85), (replicate(char(1), 85)))
select
    @spidlow         = 0
   ,@spidhigh        = 32767
--------------------  Capture consistent sysprocesses.  -------------------
SELECT
  spid
 ,status
 ,sid
 ,hostname
 ,program_name
 ,cmd
 ,cpu
 ,physical_io
 ,blocked
 ,dbid
 ,convert(sysname, rtrim(loginame))
        as loginname
 ,nt_username as username --FB: 2001-05-21
 ,spid as 'spid_sort'
 ,  substring( convert(varchar,last_batch,111) ,6  ,5 ) + ' '
  + substring( convert(varchar,last_batch,113) ,13 ,8 )
       as 'last_batch_char'
      INTO    #tb1_sysprocesses
      from master.dbo.sysprocesses   (nolock)
--------Prepare to dynamically optimize column widths.
Select
    @charsidlow     = convert(varchar(85),@sidlow)
   ,@charsidhigh    = convert(varchar(85),@sidhigh)
   ,@charspidlow     = convert(varchar,@spidlow)
   ,@charspidhigh    = convert(varchar,@spidhigh)
SELECT
             @charMaxLenLoginName =
                  convert( varchar
                          ,isnull( max( datalength(loginname)) ,5)
                         )
            ,@charMaxLenUserName =                                  --FB: 2001-05-21
                  convert( varchar                                  --FB: 2001-05-21
                          ,isnull( max( datalength(username)) ,5)   --FB: 2001-05-21
                         )                                          --FB: 2001-05-21
            ,@charMaxLenDBName    =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,db_name(dbid)))) ,6)
                         )
            ,@charMaxLenCPUTime   =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,cpu))) ,7)
                         )
            ,@charMaxLenDiskIO    =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,physical_io))) ,6)
                         )
            ,@charMaxLenCommand  =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,cmd))) ,7)
                         )
  ,@charMaxLenHostName  =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,hostname))) ,8)
                         )
            ,@charMaxLenProgramName =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,program_name))) ,11)
                         )
            ,@charMaxLenLastBatch =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,last_batch_char))) ,9)
                         )
      from
             #tb1_sysprocesses
      where
             spid >= @spidlow
      and    spid <= @spidhigh
--------Output the report.
/***   This is the area that was modified by MFrank the most.  Exclusion for system processes included, and datalengths were modified. */
EXECUTE(
'
-- (Lo dejo como est .  FB) SET nocount off
SELECT ' + @S_2000_campos + ' From (
SELECT
             SPID          = Right( ''    '' + convert(varchar(5),spid) , 4 )
            ,ProgramName   = IsNull( NullIf( substring(program_name,1,' + @charMaxLenProgramName + ') , '''' ) , ''N S / N C'' )
            ,Status        =
                  CASE lower(status)
                     When ''sleeping'' Then CONVERT(Varchar(10),lower(status))
                     Else                   CONVERT(VARCHAR(10),upper(status))
                  END
            ,HostName      =
                  CASE hostname
                     When Null  Then ''  .''
                     When '' '' Then ''  .''
                     Else    CONVERT(Varchar(10),substring(hostname,1,' + @charMaxLenHostName + '))
                  END
            ,BlkBy         =
                  CASE               isnull(convert(char(5),blocked),''0'')
                     When ''0'' Then ''  .''
                     Else            isnull(convert(char(5),blocked),''0'')
                  END
            ,DBName        = substring(db_name(dbid),1,' + @charMaxLenDBName + ')
            ,Command       = substring(cmd,1,' + @charMaxLenCommand + ')
            ,Usuario       = CONVERT(Varchar(10),substring(username,1,' + @charMaxLenUserName + '))
            ,DiskIO        = substring(convert(varchar,physical_io),1,' + @charMaxLenDiskIO + ')
            ,Login         = CONVERT(Varchar(10),substring(loginname,1,' + @charMaxLenLoginName + '))
            ,LastBatch     = substring(last_batch_char,1,' + @charMaxLenLastBatch + ')
            ,CPUTime       = substring(convert(varchar,cpu),1,' + @charMaxLenCPUTime + ')
            ,SPID_Right    = convert(char(5),spid)  --Handy extra for right-scrolling users.
      from
             #tb1_sysprocesses  --Usually DB qualification is needed in exec().
      where
             spid >= ' + @charspidlow  + '
      and    spid <= ' + @charspidhigh + '
-- POR PARAMETRO ----------------------------------------------------------------------------------------------
      And ' + @Not + ' (
               Right( ''    '' + convert(varchar(5),spid) , 4 )                         like ''' + @S_200_loginame + '''
           Or  IsNull( NullIf( substring(program_name,1,' + @charMaxLenProgramName + ') , '''' ) , ''N S / N C'' )
                                                                                        like ''' + @S_200_loginame + '''
           Or  CASE lower(status)
                 When ''sleeping'' Then CONVERT(Varchar(10),lower(status))
                 Else                   CONVERT(VARCHAR(10),upper(status))
               END                                                                      like ''' + @S_200_loginame + '''
           Or CASE hostname
                When Null  Then ''  .''
                When '' '' Then ''  .''
                Else    CONVERT(Varchar(10),substring(hostname,1,' + @charMaxLenHostName + '))
              END                                                                       like ''' + @S_200_loginame + '''
           Or CASE               isnull(convert(char(5),blocked),''0'')
                When ''0'' Then ''  .''
                Else            isnull(convert(char(5),blocked),''0'')
              END                                                                       like ''' + @S_200_loginame + '''
           Or substring(db_name(dbid),1,' + @charMaxLenDBName + ')                      like ''' + @S_200_loginame + '''
           Or substring(cmd,1,' + @charMaxLenCommand + ')                               like ''' + @S_200_loginame + '''
           Or substring(convert(varchar,physical_io),1,' + @charMaxLenDiskIO + ')       like ''' + @S_200_loginame + '''
           Or CONVERT(Varchar(10),substring(loginname,1,' + @charMaxLenLoginName + '))  like ''' + @S_200_loginame + '''
           Or CONVERT(Varchar(10),substring(username,1,' + @charMaxLenUserName + '))    like ''' + @S_200_loginame + '''
          )
-- POR PARAMETRO ---------------------------------------------------------------------------------------------- 
'
+
@sMuestroYo
+
'
) A
    Order by spid
-- (Lo dejo como est .  FB) SET nocount on'
)
/*****AKUNDONE: removed from where-clause in above EXEC sqlstr
             sid >= ' + @charsidlow  + '
      and    sid <= ' + @charsidhigh + '
      and
**************/
LABEL_86RETURN:
if (object_id('tempdb..#tb1_sysprocesses') is not null)
            drop table #tb1_sysprocesses
return @retcode -- sp_who2
Go

If Exists ( Select 1 From SysObjects Where Name = 'sp_whoM')
  Drop Procedure sp_whoM
Go 
CREATE PROCEDURE sp_whoM  --- 1995/11/03 10:16
--    @S_200_loginame     sysname = NULL
      @S_200_loginame     varchar(200) = '%',
      @S_2000_campos       varchar(2000) = 'A.*',
      @N_1_muestroyo    numeric(1) = 0
as
/*************************************************************************************************************
**        This is a slight modification of the SP_Who SP, modified my MFrank, so that it displays 
**        information that is actually needed, and cutting back on the amount of junk displayed.
**        System processes and inactive processes are not displayed.  Column formatting has
**        been modified to display most relevant columns on one screen.  Most of the modifications
**        were made towards the end of the SP.
**************************************************************************************************************/
/*************************************************************************************************************
**        Yo, lo compile en esta base, porque no tenia permiso para usar el mismo stored procedure            
**        que se encuentra en la base master.                                                                 
**        (01/09/2000)                                                                                        
**                                                                                   Fernando                 
**                                                                                   Benavides                
**************************************************************************************************************/
/*************************************************************************************************************
** Parametros:                                                                                                
**   @S_200_loginame : Una palabra a buscar en cualquiera de los campos que devuelve el Stored                      
**               Funciones Especiales : Active = 'Not Sleeping'                                               
**               Local / Remote : 'Host_Name()' / 'Not Host_Name()'                                           
**               Act Db : 'db_name()'                                                                         
**               --> Si @S_200_loginame = 'Not %'; Busca que los campos sean diferentes a @S_200_loginame - 'Not'         
**                                                                                                            
**   @S_2000_campos   : Campos que debe devolver el Stored ( El Default son Todos )                                  
**               Deben escribirse precedidos de una a y un punto y separados por comas                        
**                                                                                                            
**   @N_1_muestroyo: Determina si el stored muestra el proceso desde el cual esta siendo invocado                 
**               O sea , si se muestra a si mismo.  ( El Default es No )                                      
**                                                                                                            
**                                                                                   Fernando                 
**                                                                                   Benavides                
**************************************************************************************************************/
set nocount on
declare
    @retcode         int
declare
    @sidlow         varbinary(85)
   ,@sidhigh        varbinary(85)
   ,@sid1           varbinary(85)
   ,@spidlow         int
   ,@spidhigh        int
declare
    @charMaxLenLoginName      varchar(6)
   ,@charMaxLenUserName       varchar(6) --FB: 2001-05-21
   ,@charMaxLenDBName         varchar(6)
   ,@charMaxLenCPUTime        varchar(10)
   ,@charMaxLenDiskIO         varchar(10)
   ,@charMaxLenHostName       varchar(10)
   ,@charMaxLenProgramName    varchar(10)
   ,@charMaxLenLastBatch      varchar(10)
   ,@charMaxLenCommand        varchar(10)
declare
    @charsidlow               varchar(85)
   ,@charsidhigh              varchar(85)
   ,@charspidlow              varchar(11)
   ,@charspidhigh             varchar(11)
declare
    @Not                      varchar(3),
    @sMuestroYo               varchar(20)
--------
--Campos:
Set @S_2000_campos = LTrim( RTrim( @S_2000_campos ) )
If len(@S_2000_campos) < 3
  Begin
    Print 'CUIDADO: @S_2000_campos demasiado corto'
    Set @S_2000_campos = 'A.*'
  End
If @S_2000_campos <> 'A.*'
  Begin
    If CharIndex(' ', @S_2000_campos , 0 ) > 0 Or CharIndex(',' , @S_2000_campos , 0 ) > 0
      Begin
        Exec sp_whom_vcampos @S_2000_campos output
      End
    Else
      Begin
        If Left(@S_2000_campos,2) <> 'A.'
          Begin
            Print 'CUIDADO: Los nombres de los campos deben empezar con A.'
            Set @S_2000_campos = 'A.*'
          End
      End
  End
--------
--MuestroYo:
Select @sMuestroYo = Case
                       When @N_1_muestroyo = 0 Then ' and Spid != @@Spid '
                       Else ''
                     End
--Funciones Especiales:
If @S_200_loginame = 'Active'           Select @S_200_loginame = 'not sleeping'
If @S_200_loginame = 'Not Active'       Select @S_200_loginame = 'sleeping'
If @S_200_loginame = 'Local'            Select @S_200_loginame = host_name()
If @S_200_loginame = 'Not Local'        Select @S_200_loginame = 'not ' + host_name()
If @S_200_loginame = 'Remote'           Select @S_200_loginame = 'not ' + host_name()
If @S_200_loginame = 'Not Remote'       Select @S_200_loginame = host_name()
If @S_200_loginame = 'Act db'           Select @S_200_loginame = db_name()
If @S_200_loginame = 'Not Act db'       Select @S_200_loginame = 'not ' + db_name()
If @S_200_loginame like 'N%S%/%N%C'     Select @S_200_loginame = 'N S / N C'
If @S_200_loginame like 'Not N%S%/%N%C' Select @S_200_loginame = 'Not N S / N C'
--Si Loginame es 'Not %' ==> !=
If Len(@S_200_loginame) > 4 And @S_200_loginame like 'Not %'
  Begin
    Select @Not      = 'Not'
    Select @S_200_loginame = SubString( @S_200_loginame , 5 , 100 )
  End
Else
  Select @Not = ''
select
    @retcode         = 0      -- 0=good ,1=bad.
--------defaults
select @sidlow = convert(varbinary(85), (replicate(char(0), 85)))
select @sidhigh = convert(varbinary(85), (replicate(char(1), 85)))
select
    @spidlow         = 0
   ,@spidhigh        = 32767
--------------------  Capture consistent sysprocesses.  -------------------
SELECT
  spid
 ,status
 ,sid
 ,hostname
 ,program_name
 ,cmd
 ,cpu
 ,physical_io
 ,blocked
 ,dbid
 ,convert(sysname, rtrim(loginame))
        as loginname
 ,nt_username as username --FB: 2001-05-21
 ,spid as 'spid_sort'
 ,  substring( convert(varchar,last_batch,111) ,6  ,5 ) + ' '
  + substring( convert(varchar,last_batch,113) ,13 ,8 )
       as 'last_batch_char'
      INTO    #tb1_sysprocesses
      from master.dbo.sysprocesses   (nolock)
--------Screen out any rows?
   DELETE #tb1_sysprocesses
         where   lower(status)  = 'sleeping'
         and     upper(cmd)    IN (
                     'AWAITING COMMAND'
                    ,'MIRROR HANDLER'
                    ,'LAZY WRITER'
                    ,'CHECKPOINT SLEEP'
                    ,'RA MANAGER'
                                  )
         and     blocked       = 0
--------Prepare to dynamically optimize column widths.
Select
    @charsidlow     = convert(varchar(85),@sidlow)
   ,@charsidhigh    = convert(varchar(85),@sidhigh)
   ,@charspidlow     = convert(varchar,@spidlow)
   ,@charspidhigh    = convert(varchar,@spidhigh)
SELECT
             @charMaxLenLoginName =
                  convert( varchar
               ,isnull( max( datalength(loginname)) ,5)
                         )
            ,@charMaxLenUserName =                                  --FB: 2001-05-21
                  convert( varchar                                  --FB: 2001-05-21
                          ,isnull( max( datalength(username)) ,5)   --FB: 2001-05-21
                         )                                          --FB: 2001-05-21
            ,@charMaxLenDBName    =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,db_name(dbid)))) ,6)
                         )
            ,@charMaxLenCPUTime   =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,cpu))) ,7)
                         )
            ,@charMaxLenDiskIO    =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,physical_io))) ,6)
                         )
            ,@charMaxLenCommand  =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,cmd))) ,7)
                         )
            ,@charMaxLenHostName  =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,hostname))) ,8)
                         )
            ,@charMaxLenProgramName =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,program_name))) ,11)
                         )
            ,@charMaxLenLastBatch =
                  convert( varchar
                          ,isnull( max( datalength( convert(varchar,last_batch_char))) ,9)
                         )
      from
             #tb1_sysprocesses
      where
             spid >= @spidlow
      and    spid <= @spidhigh
--------Output the report.
/***   This is the area that was modified by MFrank the most.  Exclusion for system processes included, and datalengths were modified. */
EXECUTE(
'
-- (Lo dejo como est .  FB) SET nocount off
SELECT ' + @S_2000_campos + ' From (
SELECT
             SPID          = Right( ''    '' + convert(varchar(5),spid) , 4 )
            ,ProgramName   = IsNull( NullIf( substring(program_name,1,' + @charMaxLenProgramName + ') , '''' ) , ''N S / N C'' )
            ,Status        =
                  CASE lower(status)
                     When ''sleeping'' Then CONVERT(Varchar(10),lower(status))
                     Else                   CONVERT(VARCHAR(10),upper(status))
                  END
            ,HostName      =
                  CASE hostname
                     When Null  Then ''  .''
                     When '' '' Then ''  .''
                     Else    CONVERT(Varchar(10),substring(hostname,1,' + @charMaxLenHostName + '))
                  END
            ,BlkBy         =
                  CASE               isnull(convert(char(5),blocked),''0'')
                     When ''0'' Then ''  .''
                     Else            isnull(convert(char(5),blocked),''0'')
                  END
            ,DBName        = substring(db_name(dbid),1,' + @charMaxLenDBName + ')
            ,Command       = substring(cmd,1,' + @charMaxLenCommand + ')
            ,Usuario       = CONVERT(Varchar(10),substring(username,1,' + @charMaxLenUserName + '))
            ,DiskIO        = substring(convert(varchar,physical_io),1,' + @charMaxLenDiskIO + ')
            ,Login         = CONVERT(Varchar(10),substring(loginname,1,' + @charMaxLenLoginName + '))
            ,LastBatch     = substring(last_batch_char,1,' + @charMaxLenLastBatch + ')
            ,CPUTime       = substring(convert(varchar,cpu),1,' + @charMaxLenCPUTime + ')
            ,SPID_Right    = convert(char(5),spid)  --Handy extra for right-scrolling users.
      from
             #tb1_sysprocesses  --Usually DB qualification is needed in exec().
      where
             spid >= ' + @charspidlow  + '
      and    spid <= ' + @charspidhigh + '
       AND upper(cmd)  NOT  IN (
                     '' AWAITING COMMAND''
                    ,''MIRROR HANDLER''
                    ,''LAZY WRITER''
                    ,''CHECKPOINT SLEEP''
                    ,''RA MANAGER''
                    ,''SIGNAL HANDLER''
                    ,''LOCK MONITOR'' 
                    ,''LOG WRITER''
                    ,''AWAITING COMMAND''
                                  )
-- POR PARAMETRO ----------------------------------------------------------------------------------------------
      And ' + @Not + ' (
               Right( ''    '' + convert(varchar(5),spid) , 4 )                         like ''' + @S_200_loginame + '''
           Or  IsNull( NullIf( substring(program_name,1,' + @charMaxLenProgramName + ') , '''' ) , ''N S / N C'' )
                                                                                        like ''' + @S_200_loginame + '''
           Or  CASE lower(status)
                 When ''sleeping'' Then CONVERT(Varchar(10),lower(status))
                 Else                   CONVERT(VARCHAR(10),upper(status))
               END                                                                      like ''' + @S_200_loginame + '''
           Or CASE hostname
                When Null  Then ''  .''
                When '' '' Then ''  .''
                Else    CONVERT(Varchar(10),substring(hostname,1,' + @charMaxLenHostName + '))
              END                                                                       like ''' + @S_200_loginame + '''
           Or CASE               isnull(convert(char(5),blocked),''0'')
                When ''0'' Then ''  .''
                Else            isnull(convert(char(5),blocked),''0'')
              END                                                                       like ''' + @S_200_loginame + '''
           Or substring(db_name(dbid),1,' + @charMaxLenDBName + ')                      like ''' + @S_200_loginame + '''
           Or substring(cmd,1,' + @charMaxLenCommand + ')                               like ''' + @S_200_loginame + '''
           Or substring(convert(varchar,physical_io),1,' + @charMaxLenDiskIO + ')       like ''' + @S_200_loginame + '''
           Or CONVERT(Varchar(10),substring(loginname,1,' + @charMaxLenLoginName + '))  like ''' + @S_200_loginame + '''
           Or CONVERT(Varchar(10),substring(username,1,' + @charMaxLenUserName + '))    like ''' + @S_200_loginame + '''
          )
-- POR PARAMETRO ---------------------------------------------------------------------------------------------- 
'
+
@sMuestroYo
+
'
) A
    Order by spid
-- (Lo dejo como est .  FB) SET nocount on'
)
/*****AKUNDONE: removed from where-clause in above EXEC sqlstr
             sid >= ' + @charsidlow  + '
      and    sid <= ' + @charsidhigh + '
      and
**************/
LABEL_86RETURN:
if (object_id('tempdb..#tb1_sysprocesses') is not null)
            drop table #tb1_sysprocesses
return @retcode -- sp_who2
Go

/******************************************************************************************************/

Go 

Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'sp_val_as_cpo_cpo')
  Drop Procedure sp_val_as_cpo_cpo
Go 
CREATE procedure sp_val_as_cpo_cpo
		@S_200_tabla varchar(200),
		@S_10_alias varchar(10) = ' ',
                @S_1_uso   varchar(1) = 'S', --'S' = Select ; 'U' = Update ; 'I' = Insert ; 'P' = Params de SP ; 'V' = Insert Values ; 'L' = Solo Values
                @N_1_titu  numeric(1)  = 1
as
declare @Aux  as numeric(5)
declare @Aux4 as numeric(1)
declare @Auxs as varchar(200)
declare @Auxs2 as varchar(100)
declare @i     as integer
declare @nCant as integer
set @Aux  = 0
set @Aux4 = 0
If @N_1_titu = 1
  Begin
    print 'SP_VAL_AS_CPO_CPO: (Ultima Actualizacion = 26/4/2001)'
    print 'Selecciona campos de tabla: ' + upper(@S_200_tabla)
    print 'Con alias: ' + @S_10_alias + 'Campo'
    print ''
  End
If @S_1_uso not in ('S' , 'U' , 'I' , 'P' , 'V' , 'L' )
  Begin
    Print 'Uso Incorrecto: ' + @S_1_uso
    Print 'Usos Correctos: S - Select'
    Print '                U - Update'
    Print '                I - Insert'
    Print '                P - Parametros'
    Print '                V - Insert Values'
    Print '                L - Values'
  End
select @Aux   = max(len(b.name)) + Case @S_1_uso
                                     When 'P' Then 7
                                     When 'L' Then 7
                                     When 'S' Then Len(@S_10_Alias)
                                     Else 0
                                   End 
     , @nCant = count(*)
from sysobjects a,syscolumns b
 where a.id=b.id and a.name=@S_200_tabla

declare cu cursor local forward_only read_only for
  select         Case @S_1_uso
                   When 'S' Then @S_10_alias
                   Else ' '
                 End 
               + Case @S_1_uso
                   When 'P' Then '@'
                               + Case 
                                   When b.xtype in ( 35 , 36 , 99 , 167 , 175 , 231 , 239 )
                                     Then 'C_' + LTrim( Str( b.length ) )
                                   When b.xtype in ( 34 , 48 , 52 , 56 , 59 , 60 , 62 , 104 , 106 , 108 , 122 , 165 , 173 , 189 )
                                     Then 'N_' + Ltrim( Str( b.xprec ) )
                                   When b.xtype in ( 58 , 61 )
                                     Then 'D_' + '16'
                                   Else ''
                                 End
                               + '_'  
                   When 'L' Then '@'
                               + Case 
                                   When b.xtype in ( 35 , 36 , 99 , 167 , 175 , 231 , 239 )
                                     Then 'C_' + LTrim( Str( b.length ) )
                                   When b.xtype in ( 34 , 48 , 52 , 56 , 59 , 60 , 62 , 104 , 106 , 108 , 122 , 165 , 173 , 189 )
                                     Then 'N_' + Ltrim( Str( b.xprec ) )
                                   When b.xtype in ( 58 , 61 )
                                     Then 'D_' + '16'
                                   Else ''
                                 End
                               + '_'  
                   Else ''
                 End
               + b.name 
       + Replicate( ' ' , @Aux - Len(Case @S_1_uso
                   When 'S' Then @S_10_alias
                   Else ' '
                 End 
               + Case @S_1_uso
                   When 'P' Then '@'
                               + Case 
                                   When b.xtype in ( 35 , 36 , 99 , 167 , 175 , 231 , 239 )
                                     Then 'C_' + LTrim( Str( b.length ) )
                                   When b.xtype in ( 34 , 48 , 52 , 56 , 59 , 60 , 62 , 104 , 106 , 108 , 122 , 165 , 173 , 189 )
                                     Then 'N_' + Ltrim( Str( b.xprec ) )
                                   When b.xtype in ( 58 , 61 )
                                     Then 'D_' + '16'
                                   Else ''
                                 End
                               + '_'  
                   When 'L' Then '@'
                               + Case 
                                   When b.xtype in ( 35 , 36 , 99 , 167 , 175 , 231 , 239 )
                                     Then 'C_' + LTrim( Str( b.length ) )
                                   When b.xtype in ( 34 , 48 , 52 , 56 , 59 , 60 , 62 , 104 , 106 , 108 , 122 , 165 , 173 , 189 )
                                     Then 'N_' + Ltrim( Str( b.xprec ) )
                                   When b.xtype in ( 58 , 61 )
                                     Then 'D_' + '16'
                                   Else ''
                                 End
                               + '_'  
                   Else ''
                 End
               + b.name ) + 1 )
       + case @S_1_uso
           When 'U' Then ' = && , '
           When 'P' Then ' ' 
                       + Type_Name(b.xtype) 
                       + Case
                           When b.xtype in ( 106 , 108 )
                             Then '(' 
                                + LTrim(Str(xprec)) 
                                + Case
                                    When b.xscale > 0 Then ',' 
                                                         + LTrim( Str( b.xscale ) )
                                    Else ''
                                  End + ')'
                           When b.xtype in ( 35 , 167 , 175 , 231 , 239 )
                             Then '(' + LTrim(Str(length)) + ')'
                           Else ''
                         End
                       + ', '
           Else ', '
         end
    from sysobjects a,syscolumns b
   where a.id=b.id and a.name=@S_200_tabla
order by b.colid


open cu

If @S_1_uso = 'P'
  Print 'Create Procedure SP_' + @S_200_tabla
If @S_1_uso = 'L'
  Print 'Values ('
If @S_1_uso = 'U'
  Print 'Update ' + db_name() + '..' + @S_200_tabla + ' Set'
If @S_1_uso In ( 'I' , 'V' )
  Print 'Insert Into ' + db_name() + '..' + @S_200_tabla + ' ('
If @S_1_uso = 'S'
  Print 'Select '
If @S_1_uso = 'U' Or @S_1_uso = 'P'
  Begin
    While 1=1 begin
      fetch cu into @Auxs
      if @@Fetch_Status <> 0 Break
      Set @i = IsNull(@i , 0) + 1
      Set @Auxs = '       ' + @Auxs
      print Case @i
              When @nCant Then Left( @Auxs , Len(@Auxs) - 1 )
              Else @Auxs
            End
    End
  End
Else
  Begin
        while 1=1 begin
          fetch cu into @Auxs
          if @@fetch_status <> 0 break
          Set @i = IsNull(@i , 0) + 1
          if @Aux4 = 0 begin
            set @Aux4 = 1
            set @Auxs2 = '       '
          end
          set @Auxs2 = @Auxs2 + @Auxs
          if len(@Auxs2) >= (89 - @Aux) begin
            print Case @i
                    When @nCant Then substring(@Auxs2,1,len(@Auxs2)-1)
                    Else @Auxs2
                  End
            set @Auxs2 = '       '
          end
        end
        If @Auxs2 <> '' print substring(@Auxs2,1,len(@Auxs2)-1)
  End
close cu
deallocate cu
If @S_1_uso = 'S'
  Begin
    print '  from ' + db_name() + '..' + @S_200_tabla + case
                                                    when @S_10_alias = '' then ''
                                                    else ' ' + substring(@S_10_alias,1,len(@S_10_alias)-1)
                                                  end
  End
If @S_1_uso = 'I'
  Begin
    print ')'
    Exec sp_val_as_cpo_cpo @S_200_tabla, @S_10_alias, 'S', 0
  End
If @S_1_uso = 'V'
  Begin
    Print ') '
    Exec sp_val_as_cpo_cpo @S_200_tabla, @S_10_alias, 'L', 0
  End
If @S_1_uso = 'L'
  Begin
    Print ') '
  End

Go
