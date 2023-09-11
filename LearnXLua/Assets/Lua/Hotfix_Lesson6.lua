--print("泛型类替换")

--泛型类 T是可以变化 那lua中应该如何替换呢？
--lua中的替换 要一个类型一个类型的来

xlua.hotfix(CS.HotfixTest2(CS.System.String),{
    Test = function (self,str)
        print("lua fix:"..str)
    end
})

xlua.hotfix(CS.HotfixTest2(CS.System.Int32),{
    Test = function (self,str)
        print("lua fix:"..str)
    end
})



