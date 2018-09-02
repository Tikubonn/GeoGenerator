
export MAKEFLAGS := --no-print-directory

all:
	make test.exe
	make dist/GeoGenerator.dll

test.exe: src/Position.cs src/GenericBuffer.cs src/GenericBufferException.cs src/MapData.cs src/MapNode.cs src/MapGenerator.cs src/Utility.cs src/Debug.cs src/Test.cs
	csc -out:test.exe -nologo src\\Position.cs src\\GenericBuffer.cs src\\GenericBufferException.cs src\\MapData.cs src\\MapNode.cs src\\MapGenerator.cs src\\Utility.cs src\\Debug.cs src\\Test.cs

dist/GeoGenerator.dll: src/Position.cs src/GenericBuffer.cs src/GenericBufferException.cs src/MapData.cs src/MapNode.cs src/MapGenerator.cs src/Utility.cs src/Debug.cs 
	csc -target:library -out:dist\\GeoGenerator.dll -nologo src\\Position.cs src\\GenericBuffer.cs src\\GenericBufferException.cs src\\MapData.cs src\\MapNode.cs src\\MapGenerator.cs src\\Utility.cs src\\Debug.cs 
