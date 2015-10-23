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
            if (!currentGeneration || !currentGeneration.length){
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
            initialize: initialize,
            toNextGeneration: toNextGeneration
        }
    }

    function show(universe) {
        console.log("display");
    }

    function reGenerate() {
        console.log("reGenerate");
        var rowCount = $("#rowCount").val();
        var columnCount = $("#columnCount").val();
        var manager = createUniverseManager(rowCount, columnCount);
        var time = 1;

        var universeState = manager.initialize();
        show(universeState);
        setTimeout(evolution, time * 1000);

        function evolution() {
            var nextGeneration = manager.toNextGeneration();
            if (nextGeneration.changed) {
                show(nextGeneration.state);
                setTimeout(evolution, time * 1000);
            }
        }

    }

    $(document).ready(function () {
        $("#create").on("click", reGenerate);
        reGenerate();
    });
})();