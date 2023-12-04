@echo off
xcopy adventofcode2023\day0 adventofcode2023\day%1\
xcopy adventofcode2023.test\day0 adventofcode2023.test\day%1\
xcopy adventofcode2023.test\resources\day0 adventofcode2023.test\resources\day%1\

call substitute.bat day0 day%1 adventofcode2023\day%1\Solver.cs > adventofcode2023\day%1\tmp
copy adventofcode2023\day%1\tmp adventofcode2023\day%1\Solver.cs
del adventofcode2023\day%1\tmp

call substitute.bat day0 day%1 adventofcode2023.test\day%1\SolverTest.cs > adventofcode2023.test\day%1\tmp
copy adventofcode2023.test\day%1\tmp adventofcode2023.test\day%1\SolverTest.cs
del adventofcode2023.test\day%1\tmp