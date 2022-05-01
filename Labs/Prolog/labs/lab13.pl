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
contains([],_) :- fail,!.
contains([H|T],V) :-
    (V is H,!;contains(T,V)).

reverseList([],Result, Local) :- Result = Local.
reverseList([H|T],Result, Local) :-
    reverseList(T, Result, [H|Local]).
reverseList(List,Result) :- reverseList(List,Result, []).

pushBack(List,V,NewList) :-
    reverseList(List, ReversedList),
    reverseList([V|ReversedList], NewList).

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
inList([H|T],H).
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