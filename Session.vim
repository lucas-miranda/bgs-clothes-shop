let SessionLoad = 1
let s:so_save = &g:so | let s:siso_save = &g:siso | setg so=0 siso=0 | setl so=-1 siso=-1
let v:this_session=expand("<sfile>:p")
silent only
silent tabonly
cd ~/repos/UnityProjects/bgs-clothes-shop
if expand('%') == '' && !&modified && line('$') <= 1 && getline(1) == ''
  let s:wipebuf = bufnr('%')
endif
let s:shortmess_save = &shortmess
if &shortmess =~ 'A'
  set shortmess=aoOA
else
  set shortmess=aoO
endif
badd +2 Clothes\ Shop/Assets/Game/Scripts/Player/PlayerMove.cs
badd +1 ~/repos/UnityProjects/bgs-clothes-shop/Clothes\ Shop/Assets/Game/Scripts/Player/PlayerInteract.cs
badd +27 Clothes\ Shop/Assets/Game/Scripts/Interactable.cs
badd +13 Clothes\ Shop/Assets/Game/Scripts/UI/ShopUI.cs
badd +11 Clothes\ Shop/Assets/Game/Scripts/NPC/ClothierNPC.cs
badd +14 Clothes\ Shop/Assets/Game/Scripts/NPC/Clothier/ClothierNPC.cs
badd +5 ~/repos/UnityProjects/bgs-clothes-shop/Clothes\ Shop/Assets/Game/Scripts/Shop/ShopData.cs
badd +6 ~/repos/UnityProjects/bgs-clothes-shop/Clothes\ Shop/Assets/Game/Scripts/Shop/ShopEntryData.cs
argglobal
%argdel
set stal=2
tabnew +setlocal\ bufhidden=wipe
tabnew +setlocal\ bufhidden=wipe
tabnew +setlocal\ bufhidden=wipe
tabrewind
edit Clothes\ Shop/Assets/Game/Scripts/Player/PlayerMove.cs
argglobal
let s:l = 6 - ((5 * winheight(0) + 24) / 48)
if s:l < 1 | let s:l = 1 | endif
keepjumps exe s:l
normal! zt
keepjumps 6
normal! 0
tabnext
edit ~/repos/UnityProjects/bgs-clothes-shop/Clothes\ Shop/Assets/Game/Scripts/Player/PlayerInteract.cs
let s:save_splitbelow = &splitbelow
let s:save_splitright = &splitright
set splitbelow splitright
wincmd _ | wincmd |
vsplit
1wincmd h
wincmd w
wincmd _ | wincmd |
split
1wincmd k
wincmd w
let &splitbelow = s:save_splitbelow
let &splitright = s:save_splitright
wincmd t
let s:save_winminheight = &winminheight
let s:save_winminwidth = &winminwidth
set winminheight=0
set winheight=1
set winminwidth=0
set winwidth=1
exe 'vert 1resize ' . ((&columns * 94 + 87) / 174)
exe '2resize ' . ((&lines * 17 + 23) / 47)
exe 'vert 2resize ' . ((&columns * 5 + 87) / 174)
exe '3resize ' . ((&lines * 30 + 23) / 47)
exe 'vert 3resize ' . ((&columns * 5 + 87) / 174)
argglobal
balt Clothes\ Shop/Assets/Game/Scripts/Player/PlayerMove.cs
let s:l = 18 - ((17 * winheight(0) + 24) / 48)
if s:l < 1 | let s:l = 1 | endif
keepjumps exe s:l
normal! zt
keepjumps 18
normal! 0
wincmd w
argglobal
if bufexists(fnamemodify("Clothes\ Shop/Assets/Game/Scripts/Interactable.cs", ":p")) | buffer Clothes\ Shop/Assets/Game/Scripts/Interactable.cs | else | edit Clothes\ Shop/Assets/Game/Scripts/Interactable.cs | endif
if &buftype ==# 'terminal'
  silent file Clothes\ Shop/Assets/Game/Scripts/Interactable.cs
endif
balt ~/repos/UnityProjects/bgs-clothes-shop/Clothes\ Shop/Assets/Game/Scripts/Player/PlayerInteract.cs
let s:l = 27 - ((0 * winheight(0) + 8) / 17)
if s:l < 1 | let s:l = 1 | endif
keepjumps exe s:l
normal! zt
keepjumps 27
normal! 034|
wincmd w
argglobal
if bufexists(fnamemodify("Clothes\ Shop/Assets/Game/Scripts/NPC/ClothierNPC.cs", ":p")) | buffer Clothes\ Shop/Assets/Game/Scripts/NPC/ClothierNPC.cs | else | edit Clothes\ Shop/Assets/Game/Scripts/NPC/ClothierNPC.cs | endif
if &buftype ==# 'terminal'
  silent file Clothes\ Shop/Assets/Game/Scripts/NPC/ClothierNPC.cs
endif
balt Clothes\ Shop/Assets/Game/Scripts/Interactable.cs
let s:l = 1 - ((0 * winheight(0) + 15) / 30)
if s:l < 1 | let s:l = 1 | endif
keepjumps exe s:l
normal! zt
keepjumps 1
normal! 0
wincmd w
exe 'vert 1resize ' . ((&columns * 94 + 87) / 174)
exe '2resize ' . ((&lines * 17 + 23) / 47)
exe 'vert 2resize ' . ((&columns * 5 + 87) / 174)
exe '3resize ' . ((&lines * 30 + 23) / 47)
exe 'vert 3resize ' . ((&columns * 5 + 87) / 174)
tabnext
edit Clothes\ Shop/Assets/Game/Scripts/UI/ShopUI.cs
argglobal
balt Clothes\ Shop/Assets/Game/Scripts/Interactable.cs
let s:l = 53 - ((33 * winheight(0) + 22) / 45)
if s:l < 1 | let s:l = 1 | endif
keepjumps exe s:l
normal! zt
keepjumps 53
normal! 033|
tabnext
edit Clothes\ Shop/Assets/Game/Scripts/NPC/Clothier/ClothierNPC.cs
argglobal
balt Clothes\ Shop/Assets/Game/Scripts/UI/ShopUI.cs
let s:l = 14 - ((13 * winheight(0) + 22) / 45)
if s:l < 1 | let s:l = 1 | endif
keepjumps exe s:l
normal! zt
keepjumps 14
normal! 030|
tabnext 3
set stal=1
if exists('s:wipebuf') && len(win_findbuf(s:wipebuf)) == 0 && getbufvar(s:wipebuf, '&buftype') isnot# 'terminal'
  silent exe 'bwipe ' . s:wipebuf
endif
unlet! s:wipebuf
set winheight=1 winwidth=20
let &shortmess = s:shortmess_save
let s:sx = expand("<sfile>:p:r")."x.vim"
if filereadable(s:sx)
  exe "source " . fnameescape(s:sx)
endif
let &g:so = s:so_save | let &g:siso = s:siso_save
set hlsearch
let g:this_session = v:this_session
let g:this_obsession = v:this_session
doautoall SessionLoadPost
unlet SessionLoad
" vim: set ft=vim :
