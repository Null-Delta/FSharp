:- ['lab12', 'library'].

%task39
printArrayWithStep2([], _).
printArrayWithStep2([H|T], Index) :-
    0 is Index mod 2,
    NewIndex is Index + 1,
    write(H),write(', '),
    printArrayWithStep2(T, NewIndex),!.
printArrayWithStep2([_|T], Index) :-
    NewIndex is Index + 1,
    printArrayWithStep2(T, NewIndex),!.

printArrayParts(List) :-
    printArrayWithStep2(List,1),
    nl,
    printArrayWithStep2(List,0).
    
%task45
findSum([],_,_,R,R).
findSum([H|T],A,B,R,LR) :-
    H =< B,
    H >= A,
    NewLR is LR + H,
    findSum(T,A,B,R,NewLR).
findSum([_|T],A,B,R,LR) :- findSum(T,A,B,R,LR).
findSum(List,A,B,R) :- findSum(List,A,B,R,0).

%task51
contains([H|T],V) :- inList([H|T],V).

contains([H|T],V) :-
    (equalLists(H,V); contains(T,V)),!.

generateList1([],R,R).
generateList1([H|T], Result, LocalResult) :-
    not(contains(LocalResult,H)),
    pushBack(LocalResult, H, NewLocal),
    generateList1(T,Result,NewLocal),!.
generateList1([_|T], Result, LocalResult) :-
    generateList1(T,Result,LocalResult),!.
generateList1(List,Result) :- generateList1(List, Result, []).

findCount([],_,R,R).

findCount([H|T],V,R,LR) :-
    equalLists(H,V), 
    NewLR is LR + 1,
    findCount(T,V,R,NewLR),!;
    findCount(T,V,R,LR).

findCount([H|T],V,R,LR) :-
    not(is_list(H)),
    H is V, 
    NewLR is LR + 1,
    findCount(T,V,R,NewLR),!;
    findCount(T,V,R,LR).
findCount(List,V,R) :- findCount(List,V,R,0).

generateList2(_,[],R,R).
generateList2(List,[H|T],List2,LocalList) :-
    findCount(List,H,Count),
    pushBack(LocalList, Count, NewLocal),
    generateList2(List,T,List2,NewLocal),!.
generateList2(List, List1, List2) :- generateList2(List,List1,List2,[]).

calculateLists(List,L1,L2) :-
    generateList1(List,L1),
    generateList2(List,L1,L2).

%task14
inList([H|_],H).
inList([_|T], V) :- inList(T,V).

findValues :- 
    List = [_,_,_],
    inList(List,[belocurov,_]),
    inList(List,[rizov,_]),
    inList(List,[chernov,_]),
    inList(List,[_,riziy]),
    inList(List,[_,blondin]),
    inList(List,[_,brunet]),
    not(inList(List,[rizov,riziy])),
    not(inList(List,[chernov,brunet])),
    write(List),!.

%task15
findValues2 :-
    List = [_,_,_],
    inList(List,[_,_,white]),
    inList(List,[_,_,blue]),
    inList(List,[_,_,green]),
    inList(List,[_,white,_]),
    inList(List,[_,blue,_]),
    inList(List,[_,green,_]),
    inList(List,[valya,_,_]),
    inList(List,[anya,A,A]),
    inList(List,[natasha,green,_]),
    not(inList(List,[valya,B,B])),
    not(inList(List,[natasha,C,C])),
    not(inList(List,[valya,white,_])),
    not(inList(List,[valya,_,white])),
    write(List),!.

%task16
findValues3 :-
    List = [_,_,_],
    inList(List,[_,_,1]),
    inList(List,[_,_,2]),
    inList(List,[A,slesar,0]),
    inList(List,[B,svarshik,_]),
    inList(List,[C,tokar,E]),
    inList(List,[boris,_,_]),
    inList(List,[ivanov,_,_]),
    inList(List,[semenov,_,D]),
    D > E,
    write('слесарь: '),write(A),write(', '),
    write('сварщик: '),write(B),write(', '),
    write('токарь: '),write(C),nl,
    write(List),!.
    
%task17
betweenList(_,_,_, [_,_]) :- fail,!.
betweenList(Center,FstSide,SndSide, [FstSide,Center,SndSide|_]) :- !.
betweenList(Center,FstSide,SndSide, [SndSide,Center,FstSide|_]) :- !.
betweenList(Center,FstSide,SndSide, [_,H2,H3|T]) :-
    betweenList(Center, FstSide, SndSide, [H2,H3|T]),!.
    
neibhor(Value1,Value2, [Value1,Value2|_]).
neibhor(Value1,Value2, [Value2,Value1|_]).
neibhor(_,_, [_,_|_]) :- fail,!.
neibhor(Value1,Value2, [_,H2|T]) :- neibhor(Value1,Value2,[H2|T]),!.

findValues4 :-
    List = [_,_,_,_],
    inList(List,[butilka,_]),
    inList(List,[stakan,_]),
    inList(List,[kuvshin,_]),
    inList(List,[banka,_]),
    inList(List,[_,moloko]),
    inList(List,[_,limonade]),
    inList(List,[_,kvAss]),
    inList(List,[_,voda]),
    not(inList(List,[butilka,moloko])),
    not(inList(List,[butilka,voda])),
    not(inList(List,[banka,limonade])),
    not(inList(List,[banka,voda])),
    neibhor([stakan,_],[banka,_],List),
    neibhor([stakan,_],[_,moloko],List),
    betweenList([_,limonade],[_,kvAss],[kuvshin,_],List),
    write(List),!.

%task18
findValues5 :-
    List = [_,_,_,_],
    inList(List,[voronov,_]),
    inList(List,[pavlov,_]),
    inList(List,[levizkiy,_]),
    inList(List,[saharov,_]),
    inList(List,[_,dancer]),
    inList(List,[_,artist]),
    inList(List,[_,singer]),
    inList(List,[_,writer]),
    not(inList(List,[voronov,singer])),
    not(inList(List,[levizkiy,singer])),
    not(inList(List,[pavlov,writer])),
    not(inList(List,[saharov,writer])),
    not(inList(List,[voronov,writer])),
    not(inList(List,[pavlov,artist])),
    write(List),!.

%task19
findValues6 :-
    List = [_,_,_],
    inList(List, [_,_,_,1]),
    inList(List, [_,_,_,2]),
    inList(List, [_,_,_,3]),
    inList(List,[_,_,american,B]),
    inList(List,[_,_,isralian,_]),
    inList(List,[_,_,australian,_]),

    inList(List,[_,basketball,_,_]),
    inList(List,[_,tennis,_,D]),
    inList(List,[_,kriket,_,1]),

    inList(List,[maikl,basketball,_,A]),
    inList(List,[saimon,_,isralian,C]),
    inList(List,[richard,_,_,_]),
    not(
        inList(List,[maikl,_,isralian,_]);
        inList(List,[maikl,_,american,_])
    ),
    A < B,
    C < D,
    write(List),!.

%task20
findValues7 :-
    List = [_,_,_],
    inList(List,[petr,_]),
    inList(List,[roman,_]),
    inList(List,[sergey,_]),
    inList(List,[_,mathemathic]),
    inList(List,[_,chemistry]),
    inList(List,[_,physic]),
    (
        not(inList(List,[petr,mathemathic]));
        inList(List,[sergey,physic])
    ),
    (
        inList(List,[roman,physic]);
        inList(List,[petr,mathemathic])
    ),
    (
        inList(List,[sergey,mathemathic]);
        inList(List,[roman,physic])    
    ),
    write(List),!.