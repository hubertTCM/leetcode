"use strict";
(function () {
    var state = { live: "live", dead: "dead" };
    var universeState = {}; // {x, y, state}

    function createUniverseManager(rowCount, columnCount) {
        var currentGeneration;

        // 8 directions, clockwise
        var neighborLocationCalculator = {
            NW: function (location) {
                return { rowIndex: location.rowIndex - 1, columnIndex: location.columnIndex - 1 };
            },
            N: function (location) {
                return { rowIndex: location.rowIndex, columnIndex: location.columnIndex - 1 };
            },
            NE: function (location) {
                return { rowIndex: location.rowIndex + 1, columnIndex: location.columnIndex - 1 };
            },
            E: function (location) {
                return { rowIndex: location.rowIndex + 1, columnIndex: location.columnIndex };
            },
            SE: function (location) {
                return { rowIndex: location.rowIndex + 1, columnIndex: location.columnIndex + 1 };
            },
            S: function (location) {
                return { rowIndex: location.rowIndex, columnIndex: location.columnIndex + 1 };
            },
            SW: function (location) {
                return { rowIndex: location.rowIndex - 1, columnIndex: location.columnIndex + 1 };
            },
            W: function (location) {
                return { rowIndex: location.rowIndex - 1, columnIndex: location.columnIndex };
            }
        }

        function getState(rowIndex, columnIndex) {
            if (!currentGeneration || !currentGeneration.length) {
                return state.dead;
            }

            if (rowIndex < 0 || rowIndex >= rowCount ||
                columnIndex < 0 || columnIndex >= columnCount) {
                return state.dead;
            }

            var row = currentGeneration[rowIndex];
            return row[columnIndex];
        }


        function calcuateLiveNeighbors(rowIndex, columnIndex) {
            var liveNeighbors = 0;
            var location = { rowIndex: rowIndex, columnIndex: columnIndex };
            var direction;
            for (direction in neighborLocationCalculator) {
                var neighbor = neighborLocationCalculator[direction](location);
                var neighborState = getState(neighbor.rowIndex, neighbor.columnIndex);
                if (neighborState == state.live) {
                    liveNeighbors += 1;
                }
            }
            return liveNeighbors;
        }


        function getColumnCount() {
            return columnCount;
        }

        function getRowCount() {
            return rowCount;
        }

        function getNextGenerationState(currentState, liveNeighbors) {
            var overPopulationLimit = 3;
            var underPopulationLimt = 2;
            var reproduction = 3;

            if (currentState == state.live) {
                if (liveNeighbors > overPopulationLimit ||
                    liveNeighbors < underPopulationLimt) {
                    return state.dead;
                }
                return state.live;
            }

            if (liveNeighbors == reproduction) {
                return state.live;
            }

            return state.dead;
        }

        function toNextGeneration() {
            if (!currentGeneration) {
                initialize();
                return { changed: true, state: currentGeneration };
            }

            var nextGneration = [];

            var changed = false;
            var row;
            var currentState, liveNeighbors;
            var nextState;
            var rowIndex = 0;
            var columnIndex = 0;
            for (rowIndex; rowIndex < rowCount; ++rowIndex) {
                row = []
                for (columnIndex = 0; columnIndex < columnCount; ++columnIndex) {
                    currentState = getState(rowIndex, columnIndex);
                    liveNeighbors = calcuateLiveNeighbors(rowIndex, columnIndex);
                    nextState = getNextGenerationState(currentState, liveNeighbors);
                    row.push(nextState);
                    if (nextState != currentState) {
                        changed = true;
                    }
                }
                nextGneration.push(row);
            }

            currentGeneration = nextGneration;
            return { changed: changed, state: nextGneration };
        }

        function initialize() {
            var rowIndex = 0;
            var columnIndex = 0;
            currentGeneration = [];
            for (rowIndex; rowIndex < rowCount; ++rowIndex) {
                var row = []
                for (columnIndex = 0; columnIndex < columnCount; ++columnIndex) {

                    if (Math.random() < 0.3) {
                        row.push(state.live);
                    }
                    else {
                        row.push(state.dead);
                    }
                }

                currentGeneration.push(row);
            }
            return currentGeneration;
        };

        return {
            getRowCount: getRowCount,
            getColumnCount: getColumnCount,
            getState: getState,
            toNextGeneration: toNextGeneration
        }
    }

    var displayManager = {
        cellWidth: 10,
        cellHeight: 5
    }
    displayManager.getContext = function () {
        var context = $("#universe")[0].getContext("2d");
        return context;
    }

    displayManager.initialize = function (universeManager) {
        this.universeManager = universeManager;
        var rowCount = universeManager.getRowCount();
        var columnCount = universeManager.getColumnCount();

        //draw grid
        var context = this.getContext();
        var width, height;
        width = this.cellWidth * columnCount;
        height = this.cellHeight * rowCount;
        context.canvas.width = width;
        context.canvas.height = height;

        context.strokeStyle = "#eee";
        var rowIndex, columnIndex;
        for (rowIndex = 0; rowIndex < rowCount + 1; ++rowIndex) {
            context.moveTo(rowIndex * this.cellWidth, 0);
            context.lineTo(rowIndex * this.cellWidth, height);
        }
        for (columnIndex = 0; columnIndex < columnCount + 1; ++columnIndex) {
            context.moveTo(0, columnIndex * this.cellHeight);
            context.lineTo(width, columnIndex * this.cellHeight);
        }
        context.stroke();
    }

    displayManager.show = function () {
        var colors = {};
        colors[state.live] = "green";
        colors[state.dead] = "grey";
        var context = this.getContext();
        var rowIndex, columnIndex;
        for (rowIndex = 0; rowIndex < this.universeManager.getRowCount(); ++rowIndex) {
            for (columnIndex = 0; columnIndex < this.universeManager.getColumnCount(); ++columnIndex) {
                context.fillStyle = colors[this.universeManager.getState(rowIndex, columnIndex)];
                context.fillRect(rowIndex * this.cellWidth, columnIndex * this.cellHeight, (rowIndex + 1) * this.cellWidth, (columnIndex + 1) * this.cellHeight);
            }
        }
    }

    function reGenerate() {
        console.log("reGenerate");
        var rowCount = parseInt($("#rowCount").val());
        var columnCount = parseInt($("#columnCount").val());
        var manager = createUniverseManager(rowCount, columnCount);
        displayManager.initialize(manager);
        var time = 1;

        function evolution() {
            var nextGeneration = manager.toNextGeneration();
            if (nextGeneration.changed) {
                displayManager.show();
                setTimeout(evolution, time * 1000);
            }
        }
        evolution();
    }

    $(document).ready(function () {
        $("#create").on("click", reGenerate);
        reGenerate();
    });
})();