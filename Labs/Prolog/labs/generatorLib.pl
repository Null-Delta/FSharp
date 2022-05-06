:- ['library'].

writeResultInFile(Generator, FileName) :-
    (exists_file(FileName),delete_file(FileName); told ),
    tell(FileName),
    findall(_, Generator, _),
    told,!.

%тут описаны священные текста

:- op(1,xfy, --/).
:- op(2,xfy, /--).
:- op(3,xfy, /?-).
:- op(4,xfy, <--).
:- op(5,xfy, -?).
:- op(6,xfy, ~).

L ~ L.

%выбрать один элемент из списка
%синтаксис:
% <cписок элементов> --/ <выбранный элемент>
[H|T] --/ Element :- Element is H; T --/ Element.

%выбрать один элемент из списка и вернуть список без данного элемента
%синтаксис:
% <cписок элементов> --/ <выбранный элемент> /-- <список юез выбранного элемента>
List --/ Element /-- ListWithoutElement :- List --/ Element,removeElement(List,Element,ListWithoutElement).

%выбрать несколько элементов из списка
%синтаксис:
% <cписок элементов> /?- <кол-во элементов> --/ <выбранные элементы>
List /?- 1 --/ [Element] :- !,List --/ Element.
[H|T] /?- Count --/ Elements :- 
    NextCount is Count - 1,
    T /?- NextCount --/ NextList,
    Elements ~ [H|NextList];
    T /?- Count --/ Elements.

%выбрать несколько элементов из списка и вернуть список без данных элементов
%синтаксис:
% <cписок элементов> /?- <кол-во элементов> --/ <выбранные элементы> /-- <список без выбранных элементов>
List /?- Count --/ Elements /-- ListWithoutElements :- 
    List /?- Count --/ Elements,
    foldList(
        [LastList, Element, NewList]>>(
            LastList --/ Element /--NewList
        ),
        List,
        Elements,
        ListWithoutElements
    ).

%размещяет элемент в списке
%синтаксис:
% <cписок элементов> <-- <размещяемый элемент> 
List <-- Element :-
    List ~ [H|_],
    var(H),
    H is Element;
    List ~ [_|T],
    T <-- Element.

%размещяет элементы в списке указаное количество раз
%синтаксис:
% <cписок элементов> <-- <размещяемые элементы>  -? <кол-во размещений>
_ <-- [] -? _ :- !.
List <-- [H|T] -? Count :-
    !,
    List ~ L,
    L <-- H -? Count,
    L <-- T -? Count.

%размещяет элемент в списке указаное количество раз
%синтаксис:
% <cписок элементов> <-- <размещяемый элемент>  -? <кол-во размещений>
List <-- Element -? 1 :- !,List <-- Element.
List <-- Element -? Count :-
    NextCount is Count - 1,
    List ~ [H|T],
    var(H),
    H is Element,
    T <-- Element -? NextCount;
    List ~ [_|T],
    T <-- Element -? Count.