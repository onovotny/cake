﻿using Cake.Common.IO.Paths;
using Cake.Core.IO;
using Xunit;

namespace Cake.Common.Tests.Unit.IO.Paths
{
    public sealed class ConvertableFilePathTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_Path_Is_Null()
            {
                // Given, When
                var result = Record.Exception(() => new ConvertableFilePath(null));

                // Then
                Assert.IsArgumentNullException(result, "path");
            }
        }

        public sealed class ThePathProperty
        {
            [Fact]
            public void Should_Return_Path_Provided_To_Constructor()
            {
                // Given
                var path = new FilePath("file.txt");

                // When
                var result = new ConvertableFilePath(path).Path;

                // Then
                Assert.Same(path, result);
            }
        }

        public sealed class TheImplicitConversionOperator
        {
            public sealed class ConvertToDirectoryPath
            {
                [Fact]
                public void Should_Return_A_Representation_Of_The_Current_Instance()
                {
                    // Given
                    var path = new ConvertableFilePath("file.txt");

                    // When
                    var result = (FilePath)path;

                    // Then
                    Assert.Equal("file.txt", result.FullPath);
                }

                [Fact]
                public void Should_Return_Null_If_Convertable_Directory_Path_Is_Null()
                {
                    // Given
                    var path = (ConvertableFilePath)null;

                    // When
                    var result = (FilePath)path;

                    // Then
                    Assert.Null(result);
                }
            }

            public sealed class ConvertToString
            {
                [Fact]
                public void Should_Return_A_Representation_Of_The_Current_Instance()
                {
                    // Given
                    var path = new ConvertableFilePath("file.txt");

                    // When
                    var result = (string)path;

                    // Then
                    Assert.Equal("file.txt", result);
                }

                [Fact]
                public void Should_Return_Null_If_Convertable_Directory_Path_Is_Null()
                {
                    // Given
                    var path = (ConvertableFilePath)null;

                    // When
                    var result = (string)path;

                    // Then
                    Assert.Null(result);
                }
            }
        }
    }
}
