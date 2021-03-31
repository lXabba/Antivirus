.model small
.data
  string db 200 dup ('$')
  msg_number db '<number>$'
  msg_in db "Enter text: ", 13, 10, '$'
  msg_out db "Replace number to text: ", 13, 10, '$'
  flag db 1
  pos dw 250
  tempPos dw 0
  sizeBuf EQU 200
  nullPos EQU 250
.code
start:
 mov ax, @data
 mov ds, ax
 
 mov ah,09h ;vivod
 mov dx, offset msg_out
 int 21h

 lea dx, string
    mov bx, dx
    
    mov al, sizeBuf
    mov [bx], al
    mov ah, 0ah
    int 21h
    mov dl, 0ah
    mov ah, 2
    int 21h 
    
    
    mov cx,sizeBuf ; zadaem razmer
    xor ax,ax
    xor si,si      ; si increment
  
    cycl: 
        ;if (num[i]>=0 && num[i]<=9)
        cmp string[si],'0'       
        jl cycl_if2                    
        cmp string[si],'9'      
        jg cycl_if2              
        
            ;if (flag==true && pos==250)
            cmp flag,1
            jne cycl_continue
            cmp pos,nullPos
            jne cycl_continue
                ;pos=i
                mov pos,si
                jmp cycl_continue
            
        cycl_if2:
        ;if (num[i]==_ || num[i]==$)
        cmp string[si],' '
        jne cycl_if2_or
        jmp cycl_if2_body
        cycl_if2_or:
        cmp string[si],'$'
        jne cycl_nextif2
   
            cycl_if2_body:
            ;if (flag==true && pos!=250)
            cmp flag,1
            jne cycl_if2_body_else
            cmp pos,nullPos
            je cycl_if2_body_else
                ;pos=i
                mov tempPos,si
                mov si,pos
                mov string[si],'|'
                mov si,tempPos
            cycl_if2_body_else:
                mov flag,1
                mov pos,nullPos
                jmp cycl_continue
        
        cycl_nextif2:
        mov flag,0
        mov pos,nullPos
        
        cycl_continue: inc si         ;si++
    loop cycl
    
    mov ah,09h ;vivod
    mov dx, offset msg_out
    int 21h
    
    mov cx,sizeBuf ; zadaem razmer
    xor ax,ax
    xor si,si      ; si increment
    inc si
    inc si
    
    mov bx, 1
    mov ch, 0
    mov cl, [string+1]
    lea dx, string+2
    
    mov flag, 1
    cycl2:
        cmp string[si],'|'
        jne cycl2_if2
        mov flag,0
        jmp outputMSG
        
        cycl2_if2:
        cmp string[si],' '
        jne cycl2_if3
        mov flag,1
        
        cycl2_if3:
        cmp flag, 1
        je output
        jmp cycl2_continue
    
        output:
        mov ah, 02h
        mov dl, string[si]
        int 21h
        jmp cycl2_continue
        
        outputMSG:
        mov ah, 09h
        mov dx, offset msg_number
        int 21h
        
        cycl2_continue:
        inc si         ;si++
    loop cycl2 
    

exit:

    mov ah, 4ch
    int 21h

    

end start
