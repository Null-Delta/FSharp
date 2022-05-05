equalLists(L,L).

%получить значение по индексу
getValue([H|T],Index,X) :- 
    not(is_list(H)),
    (0 is Index, X is H; NewIndex is Index - 1,getValue(T,NewIndex,X)).
getValue([H|T],Index,X) :- 
    (0 is Index, equalLists(X, H); NewIndex is Index - 1,getValue(T,NewIndex,X)).

%разворот списка
reverseList([],Result, Local) :- Result = Local.
reverseList([H|T],Result, Local) :-
    reverseList(T, Result, [H|Local]).
reverseList(List,Result) :- reverseList(List,Result, []).

%добавить элемент в конец списка
pushBack(List,V,NewList) :-
    reverseList(List, ReversedList),
    reverseList([V|ReversedList], NewList).

%удалить элемент по индексу
removeByIndex([_|T], 0, NewList, LocalList) :-
    concatenate(LocalList, T, ConcatenatedList),
    equalLists(NewList, ConcatenatedList).

removeByIndex([H|T], Index, NewList, LocalList) :-
    NewIndex is Index - 1,
    pushBack(LocalList, H, NewLocalList),
    removeByIndex(T,NewIndex, NewList, NewLocalList).

removeByIndex(List, Index, NewList) :- removeByIndex(List, Index, NewList, []),!.

%удалить элемент
removeElement([H|T], H, NewList, LocalList) :-
    concatenate(LocalList, T, ConcatenatedList),
    equalLists(NewList, ConcatenatedList).

removeElement([H|T], Value, NewList, LocalList) :-
    pushBack(LocalList, H, NewLocalList),
    removeElement(T,Value, NewList, NewLocalList).

removeElement(List, Value, NewList) :- removeElement(List, Value, NewList, []),!.

%кастомный мап
mapList(_,[], []).
mapList(Func,[IH|IT], [OH|OT]) :-
    mapList(Func, IT, OT),
    call(Func,IH,OH),!.

%кастомный мап
filterList(_, [], Result, Result).
filterList(Predicate, [H|T], FilteredList, LocalList) :-
    call(Predicate, H),
    pushBack(LocalList, H, NewLocalList),
    filterList(Predicate, T, FilteredList, NewLocalList);
    filterList(Predicate,T,FilteredList, LocalList).
filterList(Predicate, List, FilteredList) :- filterList(Predicate, List, FilteredList, []).

%кастомный фолд
foldList(_,Result,[], Result) :- !.
foldList(Folder,State,[H|T], Output) :- 
    call(Folder, State, H, NewState),
    foldList(Folder, NewState, T, Output),!.

%объединение списков
concatenate(List1, [], List1).
concatenate(List1, [H|T], ResultList) :-
    pushBack(List1, H, NewList1),
    concatenate(NewList1,T,ResultList),!.

allList(Predicate, []).
allList(Predicate, [H|T]) :-
    call(Predicate,H),
    allList(Predicate,T),!.